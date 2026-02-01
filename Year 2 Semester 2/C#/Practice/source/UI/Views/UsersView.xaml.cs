using Data.Models;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Services.Models;
using System.Windows.Controls;

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
    }
}
