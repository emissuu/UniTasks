using Data.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace UI.Windows
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        private IServiceProvider _services;
        private User _activeUser;
        public Main(User user, IServiceProvider services)
        {
            _activeUser = user;
            _services = services;
            InitializeComponent();
            UserName.Text = "Shout out to " + user.UserName + '!';
        }
    }
}
