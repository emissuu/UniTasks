using Data.Models;
using System.Windows.Controls;

namespace UI.Views
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : UserControl
    {
        private IServiceProvider _services;
        private User _activeUser;
        public DashboardView(User user, IServiceProvider services)
        {
            _activeUser = user;
            _services = services;
            InitializeComponent();
        }
    }
}
