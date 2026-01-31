using Data.Models;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace UI.Windows
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private IServiceProvider _services;
        public User? UserKey = null;
        public Login(IServiceProvider services)
        {
            _services = services;
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            if (BorderLogin.IsVisible)
            {
                BorderLogin.Visibility = Visibility.Hidden;
                BorderRegister.Visibility = Visibility.Visible;
            }
            else
            {
                BorderLogin.Visibility = Visibility.Visible;
                BorderRegister.Visibility = Visibility.Hidden;
            }
        }

        private void TextBlock_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var senderTag = (string)(sender as TextBlock).Tag;
            if (senderTag == "0")
            {
                if (PasswordVisible.IsVisible)
                {
                    PasswordVisible.Visibility = Visibility.Hidden;
                    TextBoxPassword.Text = PasswordBoxPassword.Password;
                    PasswordBoxPassword.Password = string.Empty;
                    PasswordBoxPassword.Visibility = Visibility.Hidden;
                    TextBoxPassword.Visibility = Visibility.Visible;
                }
                else
                {
                    PasswordVisible.Visibility = Visibility.Visible;
                    PasswordBoxPassword.Password = TextBoxPassword.Text;
                    TextBoxPassword.Text = string.Empty;
                    TextBoxPassword.Visibility = Visibility.Hidden;
                    PasswordBoxPassword.Visibility = Visibility.Visible;
                }
            }
            else if (senderTag == "1")
            {
                if (PasswordRegVisible.IsVisible)
                {
                    PasswordRegVisible.Visibility = Visibility.Hidden;
                    TextBoxRegPassword.Text = PasswordBoxRegPassword.Password;
                    PasswordBoxRegPassword.Password = string.Empty;
                    PasswordBoxRegPassword.Visibility = Visibility.Hidden;
                    TextBoxRegPassword.Visibility = Visibility.Visible;
                }
                else
                {
                    PasswordRegVisible.Visibility = Visibility.Visible;
                    PasswordBoxRegPassword.Password = TextBoxRegPassword.Text;
                    TextBoxRegPassword.Text = string.Empty;
                    TextBoxRegPassword.Visibility = Visibility.Hidden;
                    PasswordBoxRegPassword.Visibility = Visibility.Visible;
                }
            }
            else if (senderTag == "2")
            {
                if (PasswordRegVisibleConfirm.IsVisible)
                {
                    PasswordRegVisibleConfirm.Visibility = Visibility.Hidden;
                    TextBoxRegPasswordConfirm.Text = PasswordBoxRegPasswordConfirm.Password;
                    PasswordBoxRegPasswordConfirm.Password = string.Empty;
                    PasswordBoxRegPasswordConfirm.Visibility = Visibility.Hidden;
                    TextBoxRegPasswordConfirm.Visibility = Visibility.Visible;
                }
                else
                {
                    PasswordRegVisibleConfirm.Visibility = Visibility.Visible;
                    PasswordBoxRegPasswordConfirm.Password = TextBoxRegPasswordConfirm.Text;
                    TextBoxRegPasswordConfirm.Text = string.Empty;
                    TextBoxRegPasswordConfirm.Visibility = Visibility.Hidden;
                    PasswordBoxRegPasswordConfirm.Visibility = Visibility.Visible;
                }
            } 
        }

        private void RegisterUser()
        {
            var login = TextBoxRegLogin.Text;
            var email = TextBoxRegEmail.Text;
            var secret1 = PasswordRegVisible.IsVisible ? PasswordBoxRegPassword.Password : TextBoxRegPassword.Text;
            var secret2 = PasswordRegVisibleConfirm.IsVisible ? PasswordBoxRegPasswordConfirm.Password : TextBoxRegPasswordConfirm.Text;

            bool isNotNullOrWrong = true;
            {
                if (String.IsNullOrWhiteSpace(login))
                {
                    isNotNullOrWrong = false;
                    TextBlockWrongRegLogin.Text = "Login cannot be empty!";
                    TextBlockWrongRegLogin.Visibility = Visibility.Visible;
                }
                else
                {
                    TextBlockWrongRegLogin.Visibility = Visibility.Hidden;
                }
                if (String.IsNullOrWhiteSpace(email))
                {
                    isNotNullOrWrong = false;
                    TextBlockWrongRegEmail.Text = "Email cannot be empty!";
                    TextBlockWrongRegEmail.Visibility = Visibility.Visible;
                }
                else if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    isNotNullOrWrong = false;
                    TextBlockWrongRegEmail.Text = "Email must be valid!";
                    TextBlockWrongRegEmail.Visibility = Visibility.Visible;
                }
                else
                {
                    TextBlockWrongRegEmail.Visibility = Visibility.Hidden;
                }
                if (String.IsNullOrWhiteSpace(secret1))
                {
                    isNotNullOrWrong = false;
                    TextBlockWrongRegPassword.Visibility = Visibility.Visible;
                }
                else
                {
                    TextBlockWrongRegPassword.Visibility = Visibility.Hidden;
                }
                if (String.IsNullOrWhiteSpace(secret2))
                {
                    isNotNullOrWrong = false;
                    TextBlockWrongRegPasswordConfirm.Text = "Password cannot be empty!";
                    TextBlockWrongRegPasswordConfirm.Visibility = Visibility.Visible;
                }
                else if (secret1 != secret2)
                {
                    isNotNullOrWrong = false;
                    TextBlockWrongRegPasswordConfirm.Text = "Passwords don't match!";
                    TextBlockWrongRegPasswordConfirm.Visibility = Visibility.Visible;
                }
                else
                {
                    TextBlockWrongRegPasswordConfirm.Visibility = Visibility.Hidden;
                }
            }
            if (!isNotNullOrWrong)
                return;
            var loginResult = _services.GetService<IUserService>().RegisterUser(login, email, secret1);
            if (loginResult.Item1 != null)
            {
                if (loginResult.Item1 == "login")
                {
                    TextBlockWrongRegLogin.Text = "Login is already taken!";
                    TextBlockWrongRegLogin.Visibility = Visibility.Visible;
                }
                else
                {
                    TextBlockWrongRegLogin.Visibility = Visibility.Hidden;
                }
                if (loginResult.Item1 == "email")
                {
                    TextBlockWrongRegEmail.Text = "Email is already taken!";
                    TextBlockWrongRegEmail.Visibility = Visibility.Visible;
                }
                else
                {
                    TextBlockWrongRegEmail.Visibility = Visibility.Hidden;
                }
                if (loginResult.Item1 == "idk")
                {
                    TextBlockWrongRegPasswordConfirm.Text = "Couldn't register user!";
                    TextBlockWrongRegPasswordConfirm.Visibility = Visibility.Visible;
                }
                else
                {
                    TextBlockWrongRegPasswordConfirm.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                UserKey = loginResult.Item2;
                Close();
            }
        }
        private void LoginUser()
        {
            var login = TextBoxLogin.Text;
            var secret = PasswordVisible.IsVisible ? PasswordBoxPassword.Password : TextBoxPassword.Text;
            bool isNotNull = true;
            {
                if (String.IsNullOrWhiteSpace(login))
                {
                    isNotNull = false;
                    TextBlockWrongLogin.Visibility = Visibility.Visible;
                }
                else
                {
                    TextBlockWrongLogin.Visibility = Visibility.Hidden;
                }
                if (String.IsNullOrWhiteSpace(secret))
                {
                    isNotNull = false;
                    TextBlockWrongPassword.Text = "Password cannot be empty!";
                    TextBlockWrongPassword.Visibility = Visibility.Visible;
                }
                else
                {
                    TextBlockWrongPassword.Visibility = Visibility.Hidden;
                }
            }
            if (!isNotNull)
                return;
            var loginResult = _services.GetService<IUserService>().LoginUser(login, secret);
            if (loginResult == null)
            {
                TextBlockWrongPassword.Text = "Wrong login or password!";
                TextBlockWrongPassword.Visibility = Visibility.Visible;
            }
            else
            {
                TextBlockWrongPassword.Visibility = Visibility.Hidden;
                UserKey = loginResult;
                Close();
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginUser();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterUser();
        }

        private void TextBoxLogin_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter)
                return;

            e.Handled = true;
            LoginUser();
        }

        private void TextBoxRegister_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter)
                return;

            e.Handled = true;
            RegisterUser();
        }
    }
}
