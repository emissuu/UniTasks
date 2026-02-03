using Data.Models;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Services.Models;
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
        private bool _isInitialized = false;
        public ToDoView(User user, IServiceProvider services)
        {
            _activeUser = user;
            _services = services;
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            Update();
            _isInitialized = true;
        }

        public void Update()
        {
            var tasks = _services.GetService<ITaskService>().GetTaskDetailsByUserId(_activeUser.Id)
                .OrderBy(td => td.DueDate)
                .ToList();
            ItemsControlTasks.Items.Clear();
            foreach (var task in tasks)
            {
                ItemsControlTasks.Items.Add(task);
            }
        }

        private void ButtonSaveStatus_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var taskDetail = (sender as Button).DataContext as TaskDetails;
            _services.GetService<ITaskService>().Update(taskDetail.task, _activeUser.Id);
            Update();
        }
    }
}
