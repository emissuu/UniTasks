using Data.Models;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Services.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UI.Views
{
    /// <summary>
    /// Interaction logic for UsersView.xaml
    /// </summary>
    public partial class UsersView : UserControl
    {
        private IServiceProvider _services;
        private User _activeUser;
        public UsersView(User user, IServiceProvider services)
        {
            _activeUser = user;
            _services = services;
            InitializeComponent();
            UpdateUsersList();
        }
        public void UpdateUsersList()
        {
            var users = _services.GetService<IUserService>().GetAllUserDetails()
                .Where(u => u.Id != _activeUser.Id)
                .OrderBy(u => u.Role.Id)
                .ThenBy(u => u.UserName)
                .ToList();
            ListBoxUsers.Items.Clear();
            foreach (UserDetails user in users)
            {
                ListBoxUsers.Items.Add(user);
            }
        }

        private void ButtonAddUser_Click(object sender, RoutedEventArgs e)
        {
            ContentPresenterSide.Content = new ProfileView(null, null, _services);
            SidePanel.Visibility = Visibility.Visible;
        }

        private void ButtonRemoveSelected_Click(object sender, RoutedEventArgs e)
        {
            var users = ListBoxUsers.Items
                .Cast<UserDetails>()
                .ToList()
                .Where(ud => ud.IsChecked == true);
            if (users.Any(ud => ud.Role.Id == 1))
            {
                MessageBox.Show("You cannot remove administrators!", "TeamTask", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            var result = MessageBox.Show($"Are you sure you want to remove {users.Count()} users?", "TeamTask", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
                _services.GetService<IUserService>().Remove(users.Select(ud => ud.Id).ToArray());
            UpdateUsersList();
        }

        private void BorderSidePanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ContentPresenterSide.Content = null;
            SidePanel.Visibility = Visibility.Hidden;
            UpdateUsersList();
        }

        private void ButtonEditUser_Click(object sender, RoutedEventArgs e)
        {
            var user = (sender as Button).DataContext as UserDetails;
            if (user.Role.Id == 1)
            {
                MessageBox.Show("You cannot edit administrator!", "TeamTask", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            var selectedUser = _services.GetService<IUserService>().GetById(user.Id);
            ContentPresenterSide.Content = new ProfileView(selectedUser, true, _services);
            SidePanel.Visibility = Visibility.Visible;
        }
    }
}
