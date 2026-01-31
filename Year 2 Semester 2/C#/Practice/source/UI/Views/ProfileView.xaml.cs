using Data.Models;
using System.Windows.Controls;

namespace UI.Views
{
    /// <summary>
    /// Interaction logic for ProfileView.xaml
    /// </summary>
    public partial class ProfileView : UserControl
    {
        private IServiceProvider _services;
        private User _activeUser;
        public ProfileView(User user, IServiceProvider services)
        {
            _activeUser = user;
            _services = services;
            InitializeComponent();
        }
    }
}
