using Data.Models;
using System.Windows.Controls;
using System.Windows;

namespace UI.Views
{
    /// <summary>
    /// Interaction logic for ProfileView.xaml
    /// </summary>
    public partial class ProfileView : UserControl
    {
        private IServiceProvider _services;
        private User _user;
        public ProfileView(User user, IServiceProvider services)
        {
            _user = user;
            _services = services;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {

        }

        private void Update()
        {

        }

        private void ButtonSaveChanges_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void ButtonCancelChanges_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void TextBlock_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var senderTag = (string)(sender as TextBlock).Tag;
            if (senderTag == "0")
            {
                if (OldPasswordVisible.IsVisible)
                {
                    OldPasswordVisible.Visibility = Visibility.Hidden;
                    TextBoxOldPassword.Text = PasswordBoxOldPassword.Password;
                    PasswordBoxOldPassword.Password = string.Empty;
                    PasswordBoxOldPassword.Visibility = Visibility.Hidden;
                    TextBoxOldPassword.Visibility = Visibility.Visible;
                }
                else
                {
                    OldPasswordVisible.Visibility = Visibility.Visible;
                    PasswordBoxOldPassword.Password = TextBoxOldPassword.Text;
                    TextBoxOldPassword.Text = string.Empty;
                    TextBoxOldPassword.Visibility = Visibility.Hidden;
                    PasswordBoxOldPassword.Visibility = Visibility.Visible;
                }
            }
            else if (senderTag == "1")
            {
                if (NewPasswordVisible.IsVisible)
                {
                    NewPasswordVisible.Visibility = Visibility.Hidden;
                    TextBoxNewPassword.Text = PasswordBoxNewPassword.Password;
                    PasswordBoxNewPassword.Password = string.Empty;
                    PasswordBoxNewPassword.Visibility = Visibility.Hidden;
                    TextBoxNewPassword.Visibility = Visibility.Visible;
                }
                else
                {
                    NewPasswordVisible.Visibility = Visibility.Visible;
                    PasswordBoxNewPassword.Password = TextBoxNewPassword.Text;
                    TextBoxNewPassword.Text = string.Empty;
                    TextBoxNewPassword.Visibility = Visibility.Hidden;
                    PasswordBoxNewPassword.Visibility = Visibility.Visible;
                }
            }
            else if (senderTag == "2")
            {
                if (NewPasswordVisibleConfirm.IsVisible)
                {
                    NewPasswordVisibleConfirm.Visibility = Visibility.Hidden;
                    TextBoxNewPasswordConfirm.Text = PasswordBoxNewPasswordConfirm.Password;
                    PasswordBoxNewPasswordConfirm.Password = string.Empty;
                    PasswordBoxNewPasswordConfirm.Visibility = Visibility.Hidden;
                    TextBoxNewPasswordConfirm.Visibility = Visibility.Visible;
                }
                else
                {
                    NewPasswordVisibleConfirm.Visibility = Visibility.Visible;
                    PasswordBoxNewPasswordConfirm.Password = TextBoxNewPasswordConfirm.Text;
                    TextBoxNewPasswordConfirm.Text = string.Empty;
                    TextBoxNewPasswordConfirm.Visibility = Visibility.Hidden;
                    PasswordBoxNewPasswordConfirm.Visibility = Visibility.Visible;
                }
            }
        }

        private void ButtonResetPassword_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
