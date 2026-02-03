using Data.Models;
using System.Windows.Controls;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;

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
            Initialize();
        }

        public void Initialize()
        {
            if (_activeUser.RoleId == 3)
            {
                DisplayTodo.Visibility = Visibility.Visible;
            }
            else
            {
                DisplayProjects.Visibility = Visibility.Visible;
            }
            TextBlockWelcome.Text = $"Nice to see you back, {_activeUser.UserName}!";
            Update();
        }

        public void Update()
        {
            if (_activeUser.RoleId == 3)
            {
                var taskDetails = _services.GetService<ITaskService>().GetTaskDetailsByUserId(_activeUser.Id)
                    .OrderBy(t => t.DueDate)
                    .ToList();
                ItemsControlTodo.Items.Clear();
                foreach (var task in taskDetails)
                {
                    ItemsControlTodo.Items.Add(task);
                }
            }
            else
            {
                var projects = _services.GetService<IProjectService>().GetAll();
                ItemsControlProjects.Items.Clear();
                foreach (var project in projects)
                {
                    ItemsControlProjects.Items.Add(project);
                }
            }
        }
    }
}
