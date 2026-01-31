using Data.Models;
using System.Windows.Controls;

namespace UI.Views
{
    /// <summary>
    /// Interaction logic for ToDoView.xaml
    /// </summary>
    public partial class ToDoView : UserControl
    {
        private IServiceProvider _services;
        private User _activeUser;
        public ToDoView(User user, IServiceProvider services)
        {
            _activeUser = user;
            _services = services;
            InitializeComponent();
        }
    }
}
