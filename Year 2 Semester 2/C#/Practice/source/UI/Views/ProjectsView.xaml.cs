using Data.Models;
using System.Windows.Controls;

namespace UI.Views
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ProjectsView : UserControl
    {
        private IServiceProvider _services;
        private User _activeUser;
        public ProjectsView(User user, IServiceProvider services)
        {
            _activeUser = user;
            _services = services;
            InitializeComponent();
        }
    }
}
