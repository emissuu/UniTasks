using Data.Models;
using System.Windows.Controls;

namespace UI.Views
{
    /// <summary>
    /// Interaction logic for InboxView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private IServiceProvider _services;
        private User _activeUser;
        public HomeView(User user, IServiceProvider services)
        {
            _activeUser = user;
            _services = services;
            InitializeComponent();
        }
    }
}
