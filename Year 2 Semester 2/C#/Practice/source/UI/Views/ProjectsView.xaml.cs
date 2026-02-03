using Data.Models;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Services.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Task = Data.Models.Task;

namespace UI.Views
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ProjectsView : UserControl
    {
        private IServiceProvider _services;
        private User _activeUser;
        private Project? _editedProject;
        private int _editedTaskOwner;
        private Task? _editedTask;
        public ProjectsView(User user, IServiceProvider services)
        {
            _activeUser = user;
            _services = services;
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            if (_activeUser.RoleId != 1)
            {
                ButtonCreateProject.Visibility = Visibility.Collapsed;
                ButtonRemoveProject.Visibility = Visibility.Collapsed;
            }
            if (_activeUser.RoleId == 3)
            {
                ButtonRemoveTask.Visibility = Visibility.Collapsed;
            }
            foreach (var status in (string[])["New", "In Progress", "Completed", "On Hold", "Canceled"])
            {
                ComboBoxStatus.Items.Add(status);
            }
            ComboBoxStatus.SelectedIndex = 0;
            Update();
        }

        private void Update()
        {
            var projects = _services.GetService<IProjectService>().GetAll();
            ItemsControlProjects.Items.Clear();
            foreach (var project in projects)
            {
                ItemsControlProjects.Items.Add(project);
            }
        }

        private void ButtonCreateProject_Click(object sender, RoutedEventArgs e)
        {
            _editedProject = null;
            ButtonSaveChangesProject.Content = "Create Project";
            ButtonRemoveProject.Visibility = Visibility.Collapsed;
            var teams = _services.GetService<ITeamService>().GetAllTeamDetails();
            ComboBoxTeams.Items.Clear();
            foreach (var team in teams)
            {
                ComboBoxTeams.Items.Add(team);
            }
            ComboBoxTeams.SelectedIndex = 0;
            SideEditProject.Visibility = Visibility.Visible;
        }

        private void ButtonCreateTask_Click(object sender, RoutedEventArgs e)
        {
            var projectOwner = (Project)(sender as Button).DataContext as Project;
            _editedTaskOwner = projectOwner.Id;
            _editedTask = null;
            ButtonRemoveTask.Visibility = Visibility.Collapsed;
            ButtonSaveChangesTask.Content = "Create Task";
            var userDetails = projectOwner.TeamId != null
                    ? _services.GetService<IUserService>().GetUserDetailsByTeamId((int)projectOwner.TeamId)
                    : _services.GetService<IUserService>().GetAllUserDetails();
            ComboBoxAssignedTo.Items.Clear();
            foreach (var userDetail in userDetails.Where(u => u.Role.Id == 3))
            {
                ComboBoxAssignedTo.Items.Add(userDetail);
            }
            ComboBoxAssignedTo.SelectedIndex = 0;
            DateTimePickerTask.Value = DateTime.UtcNow;
            SideEditTask.Visibility = Visibility.Visible;
        }

        private void ButtonSaveChangesProject_Click(object sender, RoutedEventArgs e)
        {
            var name = TextBoxProjectName.Text;
            var details = TextBoxProjectDetails.Text;
            var teamDetails = ComboBoxTeams.SelectedItem as TeamDetails;

            if (String.IsNullOrWhiteSpace(name))
            {
                TextBlockWrongProjectName.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                TextBlockWrongProjectName.Visibility = Visibility.Hidden;
            }

            if (_editedProject  != null)
            {
                var project = _services.GetService<IProjectService>().GetById(_editedProject.Id);
                project.Name = name;
                project.Details = details;
                project.TeamId = teamDetails.Id;
                _services.GetService<IProjectService>().Update(project, _activeUser.Id);
            }
            else
            {
                _services.GetService<IProjectService>().Add(new Project()
                {
                    Name = name,
                    Details = details,
                    TeamId = teamDetails.Id,
                    CreatedById = _activeUser.Id,
                    CreatedAt = DateTime.UtcNow
                }, _activeUser.Id);
            }
            TextBoxProjectName.Text = String.Empty;
            TextBoxProjectDetails.Text = String.Empty;
            ComboBoxTeams.SelectedIndex = 0;
            SideEditProject.Visibility = Visibility.Hidden;
            Update();
        }

        private void ButtonSaveChangesTask_Click(object sender, RoutedEventArgs e)
        {
            var name = TextBoxTaskName.Text;
            var details = TextBoxTaskDetails.Text;
            var statusId = ComboBoxStatus.SelectedIndex + 1;
            var assignedTo = ComboBoxAssignedTo.SelectedItem as UserDetails;
            var dueTo = DateTimePickerTask.Value?.ToUniversalTime();

            if (String.IsNullOrWhiteSpace(name))
            {
                TextBlockWrongTaskName.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                TextBlockWrongTaskName.Visibility = Visibility.Hidden;
            }

            if (_editedTask != null)
            {
                var task = _services.GetService<ITaskService>().GetById(_editedTask.Id);
                task.Name = name;
                task.StatusId = statusId;
                task.Details = details;
                task.AssignedToId = assignedTo.Id;
                task.DueDate = (DateTime)dueTo;
                task.UpdatedAt = DateTime.UtcNow;
                _services.GetService<ITaskService>().Update(task, _activeUser.Id);
            }
            else
            {
                _services.GetService<ITaskService>().Add(new Task()
                {
                    Name = name,
                    ProjectId = _editedTaskOwner,
                    StatusId = statusId,
                    Details = details,
                    AssignedToId = assignedTo.Id,
                    DueDate = (DateTime)dueTo,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    CreatedById = _activeUser.Id
                }, _activeUser.Id);
            }
            TextBoxTaskName.Text = String.Empty;
            TextBoxTaskDetails.Text = String.Empty;
            ComboBoxStatus.SelectedIndex = 0;
            ComboBoxAssignedTo.SelectedIndex = 0;
            DateTimePickerTask.Value = DateTime.Now;
            SideEditTask.Visibility = Visibility.Hidden;
            Update();
        }

        private void ButtonEditProject_Click(object sender, RoutedEventArgs e)
        {
            if (_activeUser.RoleId != 1)
            {
                MessageBox.Show("You cannot edit projects!", "TeamTask", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            _editedProject = (sender as Button).DataContext as Project;
            ButtonSaveChangesProject.Content = "Save changes";
            ButtonRemoveProject.Visibility = Visibility.Visible;
            TextBoxProjectName.Text = _editedProject.Name;
            TextBoxProjectDetails.Text = _editedProject.Details;
            var teams = _services.GetService<ITeamService>().GetAllTeamDetails();
            ComboBoxTeams.Items.Clear();
            foreach (var team in teams)
            {
                ComboBoxTeams.Items.Add(team);
                if (team.Id == _editedProject.TeamId)
                    ComboBoxTeams.SelectedItem = team;
            }
            SideEditProject.Visibility = Visibility.Visible;
        }

        private void ButtonEditTask_Click(object sender, RoutedEventArgs e)
        {
            if (_activeUser.RoleId == 3)
            {
                MessageBox.Show("You cannot edit tasks!", "TeamTask", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            ButtonRemoveTask.Visibility = Visibility.Visible;
            _editedTask = (sender as Button).DataContext as Task;
            _editedTaskOwner = _editedTask.ProjectId;
            var projectOwner = _editedTask.Project;
            var userDetails = projectOwner.TeamId != null
                    ? _services.GetService<IUserService>().GetUserDetailsByTeamId((int)projectOwner.TeamId)
                    : _services.GetService<IUserService>().GetAllUserDetails();
            TextBoxTaskName.Text = _editedTask.Name;
            TextBoxTaskDetails.Text = _editedTask.Details;
            ComboBoxAssignedTo.Items.Clear();
            foreach (var userDetail in userDetails.Where(u => u.Role.Id == 3))
            {
                ComboBoxAssignedTo.Items.Add(userDetail);
                if (userDetail.Id == _editedTask.AssignedToId)
                    ComboBoxAssignedTo.SelectedItem = userDetail;
            }
            ComboBoxStatus.SelectedIndex = _editedTask.StatusId - 1;
            DateTimePickerTask.Value = _editedTask.DueDate.ToLocalTime();
            SideEditTask.Visibility = Visibility.Visible;
        }

        private void ButtonRemoveProject_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show($"Are you sure you want to remove {_editedProject.Name}?", "TeamTask", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                _services.GetService<IProjectService>().Delete(_editedProject.Id, _activeUser.Id);
            }
            TextBoxProjectName.Text = String.Empty;
            TextBoxProjectDetails.Text = String.Empty;
            ComboBoxTeams.SelectedIndex = 0;
            SideEditProject.Visibility = Visibility.Hidden;
            Update();
        }

        private void ButtonRemoveTask_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show($"Are you sure you want to remove {_editedTask.Name}?", "TeamTask", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            {
                _services.GetService<ITaskService>().Delete(_editedTask.Id, _activeUser.Id);
            }
            TextBoxTaskName.Text = String.Empty;
            TextBoxTaskDetails.Text = String.Empty;
            ComboBoxStatus.SelectedIndex = 0;
            ComboBoxAssignedTo.SelectedIndex = 0;
            DateTimePickerTask.Value = DateTime.Now;
            SideEditTask.Visibility = Visibility.Hidden;
            Update();
        }

        private void BorderSideProject_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBoxProjectName.Text = String.Empty;
            TextBoxProjectDetails.Text = String.Empty;
            ComboBoxTeams.SelectedIndex = 0;
            SideEditProject.Visibility = Visibility.Hidden;
        }

        private void BorderSideTask_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBoxTaskName.Text = String.Empty;
            TextBoxTaskDetails.Text = String.Empty;
            ComboBoxStatus.SelectedIndex = 0;
            ComboBoxAssignedTo.SelectedIndex = 0;
            DateTimePickerTask.Value = DateTime.Now;
            SideEditTask.Visibility = Visibility.Hidden;
        }
    }
}
