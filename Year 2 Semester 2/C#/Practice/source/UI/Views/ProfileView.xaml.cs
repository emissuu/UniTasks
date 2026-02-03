using Data.Models;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using UI.Windows;

namespace UI.Views
{
    /// <summary>
    /// Interaction logic for ProfileView.xaml
    /// </summary>
    public partial class ProfileView : UserControl
    {
        private IServiceProvider _services;
        private User? _user;
        private bool? _isEditedByAdmin;
        private int _activeUserId;
        public ProfileView(User? user, bool? isEditedByAdmin, int activeUserId, IServiceProvider services)
        {
            _user = user;
            _isEditedByAdmin = isEditedByAdmin;
            _services = services;
            _activeUserId = activeUserId;
            InitializeComponent();
            Initialize();
        }
        private void Initialize()
        {
            if (_isEditedByAdmin == true)
            {
                DisplayProfilePreview.Visibility = Visibility.Collapsed;
                TitleBar.Visibility = Visibility.Collapsed;
                this.BorderThickness = new Thickness(3, 0, 0, 0);
                Update(_user);
            }
            else if (_isEditedByAdmin == null)
            {
                DisplayProfilePreview.Visibility = Visibility.Collapsed;
                TitleBar.Visibility = Visibility.Collapsed;
                DisplayPasswordReset.Visibility = Visibility.Collapsed;
                DisplayPasswordsRegister.Visibility = Visibility.Visible;
                ButtonSaveChanges.Visibility = Visibility.Hidden;
                ButtonCancelChanges.Visibility = Visibility.Hidden;
                ButtonRegister.Visibility = Visibility.Visible;
                this.BorderThickness = new Thickness(3, 0, 0, 0);
                foreach (var role in (string[])["Manager", "Programmer"])
                    ComboBoxRoles.Items.Add(role);
                ComboBoxRoles.SelectedIndex = 0;
            }
            else
            {
                Update(_user);
            }
        }

        private void Update()
        {
            _user = _services.GetService<IUserService>().GetById(_user.Id);
            Update(_user);
        }

        private void Update(User user)
        {
            if (_isEditedByAdmin == false)
            {
                TextBlockUserName.Text = user.UserName;
                TextBlockUserRole.Text = user.Role.Name;
            }
            TextBoxUserName.Text = user.UserName;
            TextBoxEmail.Text = user.Email;
            TextBoxPhoneNumber.Text = user.PhoneNumber;
        }

        private void ButtonSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            var userName = TextBoxUserName.Text;
            var email = TextBoxEmail.Text;
            if (email == String.Empty)
                email = null;
            var phoneNumber = TextBoxPhoneNumber.Text;
            if (phoneNumber == String.Empty)
                phoneNumber = null;

            User updatedUser = _services.GetService<IUserService>().GetById(_user.Id);

            // Are fields valid?
            {
                bool isWrong = false;
                if (String.IsNullOrWhiteSpace(userName))
                {
                    isWrong = true;
                    TextBlockWrongUserName.Visibility = Visibility.Visible;
                }
                else
                {
                    TextBlockWrongUserName.Visibility = Visibility.Hidden;
                }
                if (isWrong)
                    return;
            }
            // Are there any updated values
            bool isChanged = false;
            if (userName != _user.UserName)
                isChanged = true;
            updatedUser.UserName = userName;
            if (email != _user.Email)
            {
                isChanged = true;
                updatedUser.Email = email;
            }
            if (phoneNumber != _user.PhoneNumber)
            {
                isChanged = true;
                updatedUser.PhoneNumber = phoneNumber;
            }

            if (!isChanged)
            {
                TextBlockChangesApplied.Text = "No changes were made";
                TextBlockChangesApplied.Visibility = Visibility.Visible;
                return;
            }
            TextBlockChangesApplied.Text = "Changes succesfully applied";
            TextBlockChangesApplied.Visibility = Visibility.Visible;

            _services.GetService<IUserService>().Update(updatedUser, _activeUserId);
            Update();
        }

        private void ButtonCancelChanges_Click(object sender, RoutedEventArgs e)
        {
            Update(_user);
        }

        public void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            var userName = TextBoxUserName.Text;
            var roleId = ComboBoxRoles.SelectedIndex + 2;
            var email = TextBoxEmail.Text;
            if (email == String.Empty)
                email = null;
            var phoneNumber = TextBoxPhoneNumber.Text;
            if (phoneNumber == String.Empty)
                phoneNumber = null;
            var secret1 = RegPasswordVisible.IsVisible ? PasswordBoxRegPassword.Password : TextBoxRegPassword.Text;
            var secret2 = RegPasswordVisibleConfirm.IsVisible ? PasswordBoxRegPasswordConfirm.Password : TextBoxRegPasswordConfirm.Text;

            // Are fields valid?
            {
                bool isWrong = false;
                if (String.IsNullOrWhiteSpace(userName))
                {
                    isWrong = true;
                    TextBlockWrongUserName.Visibility = Visibility.Visible;
                }
                else
                {
                    TextBlockWrongUserName.Visibility = Visibility.Hidden;
                }
                if (String.IsNullOrWhiteSpace(secret1))
                {
                    isWrong = true;
                    TextBlockWrongRegPassword.Visibility = Visibility.Visible;
                }
                else
                {
                    TextBlockWrongRegPassword.Visibility = Visibility.Hidden;
                }
                if (String.IsNullOrWhiteSpace(secret2))
                {
                    isWrong = true;
                    TextBlockWrongRegPasswordConfirm.Text = "Password cannot be empty!";
                    TextBlockWrongRegPasswordConfirm.Visibility = Visibility.Visible;
                }
                else if (secret1 != secret2)
                {
                    isWrong = true;
                    TextBlockWrongRegPasswordConfirm.Text = "Passwords do not match!";
                    TextBlockWrongRegPasswordConfirm.Visibility = Visibility.Visible;
                }
                else
                {
                    TextBlockWrongRegPasswordConfirm.Visibility = Visibility.Hidden;
                }
                if (isWrong)
                    return;
            }
            User user = new()
            {
                RoleId = roleId,
                UserName = userName,
                PasswordHash = secret1,
                Email = email,
                PhoneNumber = phoneNumber
            };
            var loginResult = _services.GetService<IUserService>().RegisterUser(user, _activeUserId);
            if (!loginResult)
            {
                TextBlockWrongUserName.Text = "Login is already taken!";
                TextBlockWrongUserName.Visibility = Visibility.Visible;
            }
            else
            {
                TextBlockWrongUserName.Visibility = Visibility.Hidden;
            };
            TextBoxUserName.Text = String.Empty;
            TextBoxEmail.Text = String.Empty;
            TextBoxPhoneNumber.Text = String.Empty;
            ComboBoxRoles.SelectedIndex = 0;
            TextBoxRegPassword.Text = String.Empty;
            TextBoxRegPasswordConfirm.Text = String.Empty;
            PasswordBoxRegPassword.Password = String.Empty;
            PasswordBoxRegPasswordConfirm.Password = String.Empty;
            return;
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
            else if (senderTag == "3")
            {
                if (RegPasswordVisible.IsVisible)
                {
                    RegPasswordVisible.Visibility = Visibility.Hidden;
                    TextBoxRegPassword.Text = PasswordBoxRegPassword.Password;
                    PasswordBoxRegPassword.Password = string.Empty;
                    PasswordBoxRegPassword.Visibility = Visibility.Hidden;
                    TextBoxRegPassword.Visibility = Visibility.Visible;
                }
                else
                {
                    RegPasswordVisible.Visibility = Visibility.Visible;
                    PasswordBoxRegPassword.Password = TextBoxRegPassword.Text;
                    TextBoxRegPassword.Text = string.Empty;
                    TextBoxRegPassword.Visibility = Visibility.Hidden;
                    PasswordBoxRegPassword.Visibility = Visibility.Visible;
                }
            }
            else if (senderTag == "4")
            {
                if (RegPasswordVisibleConfirm.IsVisible)
                {
                    RegPasswordVisibleConfirm.Visibility = Visibility.Hidden;
                    TextBoxRegPasswordConfirm.Text = PasswordBoxRegPasswordConfirm.Password;
                    PasswordBoxRegPasswordConfirm.Password = string.Empty;
                    PasswordBoxRegPasswordConfirm.Visibility = Visibility.Hidden;
                    TextBoxRegPasswordConfirm.Visibility = Visibility.Visible;
                }
                else
                {
                    RegPasswordVisibleConfirm.Visibility = Visibility.Visible;
                    PasswordBoxRegPasswordConfirm.Password = TextBoxRegPasswordConfirm.Text;
                    TextBoxRegPasswordConfirm.Text = string.Empty;
                    TextBoxRegPasswordConfirm.Visibility = Visibility.Hidden;
                    PasswordBoxRegPasswordConfirm.Visibility = Visibility.Visible;
                }
            }
        }

        private void ButtonResetPassword_Click(object sender, RoutedEventArgs e)
        {
            var secretOld = OldPasswordVisible.IsVisible ? PasswordBoxOldPassword.Password : TextBoxOldPassword.Text;
            var secretNew1 = NewPasswordVisible.IsVisible ? PasswordBoxNewPassword.Password : TextBoxNewPassword.Text;
            var secretNew2 = NewPasswordVisibleConfirm.IsVisible ? PasswordBoxNewPasswordConfirm.Password : TextBoxNewPasswordConfirm.Text;

            bool isWrong = false;
            {
                if (String.IsNullOrWhiteSpace(secretOld))
                {
                    isWrong = true;
                    TextBlockWrongOldPassword.Text = "Password cannot be empty!";
                    TextBlockWrongOldPassword.Visibility = Visibility.Visible;
                }
                else
                {
                    TextBlockWrongOldPassword.Visibility = Visibility.Hidden;
                }
                if (String.IsNullOrWhiteSpace(secretNew1))
                {
                    isWrong = true;
                    TextBlockWrongNewPassword.Visibility = Visibility.Visible;
                }
                else
                {
                    TextBlockWrongNewPassword.Visibility = Visibility.Hidden;
                }
                if (String.IsNullOrWhiteSpace(secretNew2))
                {
                    isWrong = true;
                    TextBlockWrongNewPasswordConfirm.Text = "Password cannot be empty!";
                    TextBlockWrongNewPasswordConfirm.Visibility = Visibility.Visible;
                }
                else
                {
                    TextBlockWrongNewPasswordConfirm.Visibility = Visibility.Hidden;
                }
                if (secretNew1 != secretNew2)
                {
                    isWrong = true;
                    TextBlockWrongNewPasswordConfirm.Text = "Passwords do not match!";
                    TextBlockWrongNewPasswordConfirm.Visibility = Visibility.Visible;
                }
                else
                {
                    TextBlockWrongNewPasswordConfirm.Visibility = Visibility.Hidden;
                }
            }
            if (isWrong)
                return;

            var loginResult = _services.GetService<IUserService>().ResetPassword(_user.UserName, secretOld, secretNew1, _activeUserId);
            if (loginResult)
            {
                TextBlockWrongOldPassword.Visibility = Visibility.Hidden;
                TextBlockPasswordReset.Visibility = Visibility.Visible;
            }
            else
            {
                TextBlockWrongOldPassword.Text = "Password is wrong!";
                TextBlockWrongOldPassword.Visibility = Visibility.Visible;
                return;
            }

        }
    }
}
