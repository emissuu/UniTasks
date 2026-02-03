using Data.Models;
using System.Windows;
using System.Windows.Controls;
using UI.Views;

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
            Initialize();
        }

        private void Initialize()
        {
            TextBlockUserName.Text = _activeUser.UserName;
            TextBlockUserRole.Text = _activeUser.Role.Name;
            ViewPresenter.Content = new DashboardView(_activeUser, _services);
            if (_activeUser.RoleId == 1)
            {
                ButtonUsers.Visibility = Visibility.Visible;
            }
            else if (_activeUser.RoleId == 2)
            {
                ButtonReports.Visibility = Visibility.Visible;
            }
            else if (_activeUser.RoleId == 3)
            {
                ButtonMyTodo.Visibility = Visibility.Visible;
            }
        }

        private void ButtonChangeView_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button tabButton)
            {
                string previousView = ViewPresenter.Content.GetType().Name;
                switch (tabButton.Name)
                {
                    case "ButtonHome":
                        if (ViewPresenter.Content is DashboardView)
                            return;
                        ViewPresenter.Content = new DashboardView(_activeUser, _services);
                        ButtonHome.Style = (Style)FindResource("Button.sidetab.chosen");
                        if (previousView == "ReportsView")
                            ButtonReports.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "ToDoView")
                            ButtonMyTodo.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "ProjectsView")
                            ButtonMyProjects.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "TeamsView")
                            ButtonMyTeams.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "ProfileView")
                            ButtonMyProfile.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "UsersView")
                            ButtonUsers.Style = (Style)FindResource("Button.sidetab");
                        break;
                    case "ButtonReports":
                        if (ViewPresenter.Content is ReportsView)
                            return;
                        ViewPresenter.Content = new ReportsView(_activeUser, _services);
                        ButtonReports.Style = (Style)FindResource("Button.sidetab.chosen");
                        if (previousView == "DashboardView")
                            ButtonHome.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "ToDoView")
                            ButtonMyTodo.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "ProjectsView")
                            ButtonMyProjects.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "TeamsView")
                            ButtonMyTeams.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "ProfileView")
                            ButtonMyProfile.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "UsersView")
                            ButtonUsers.Style = (Style)FindResource("Button.sidetab");
                        break;
                    case "ButtonMyTodo":
                        if (ViewPresenter.Content is ToDoView)
                            return;
                        ViewPresenter.Content = new ToDoView(_activeUser, _services);
                        ButtonMyTodo.Style = (Style)FindResource("Button.sidetab.chosen");
                        if (previousView == "DashboardView")
                            ButtonHome.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "ReportsView")
                            ButtonReports.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "ProjectsView")
                            ButtonMyProjects.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "TeamsView")
                            ButtonMyTeams.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "ProfileView")
                            ButtonMyProfile.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "UsersView")
                            ButtonUsers.Style = (Style)FindResource("Button.sidetab");
                        break;
                    case "ButtonMyProjects":
                        if (ViewPresenter.Content is ProjectsView)
                            return;
                        ViewPresenter.Content = new ProjectsView(_activeUser, _services);
                        ButtonMyProjects.Style = (Style)FindResource("Button.sidetab.chosen");
                        if (previousView == "DashboardView")
                            ButtonHome.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "ReportsView")
                            ButtonReports.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "ToDoView")
                            ButtonMyTodo.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "TeamsView")
                            ButtonMyTeams.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "ProfileView")
                            ButtonMyProfile.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "UsersView")
                            ButtonUsers.Style = (Style)FindResource("Button.sidetab");
                        break;
                    case "ButtonMyTeams":
                        if (ViewPresenter.Content is TeamsView)
                            return;
                        ViewPresenter.Content = new TeamsView(_activeUser, _services);
                        ButtonMyTeams.Style = (Style)FindResource("Button.sidetab.chosen");
                        if (previousView == "DashboardView")
                            ButtonHome.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "ReportsView")
                            ButtonReports.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "ToDoView")
                            ButtonMyTodo.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "ProjectsView")
                            ButtonMyProjects.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "ProfileView")
                            ButtonMyProfile.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "UsersView")
                            ButtonUsers.Style = (Style)FindResource("Button.sidetab");
                        break;
                    case "ButtonMyProfile":
                        if (ViewPresenter.Content is ProfileView)
                            return;
                        ViewPresenter.Content = new ProfileView(_activeUser, false, _activeUser.Id, _services);
                        ButtonMyProfile.Style = (Style)FindResource("Button.sidetab.chosen");
                        if (previousView == "DashboardView")
                            ButtonHome.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "ReportsView")
                            ButtonReports.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "ToDoView")
                            ButtonMyTodo.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "ProjectsView")
                            ButtonMyProjects.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "TeamsView")
                            ButtonMyTeams.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "UsersView")
                            ButtonUsers.Style = (Style)FindResource("Button.sidetab");
                        break;
                    case "ButtonUsers":
                        if (ViewPresenter.Content is UsersView)
                            return;
                        ViewPresenter.Content = new UsersView(_activeUser, _services);
                        ButtonUsers.Style = (Style)FindResource("Button.sidetab.chosen");
                        if (previousView == "DashboardView")
                            ButtonHome.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "ReportsView")
                            ButtonReports.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "ToDoView")
                            ButtonMyTodo.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "ProjectsView")
                            ButtonMyProjects.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "TeamsView")
                            ButtonMyTeams.Style = (Style)FindResource("Button.sidetab");
                        else if (previousView == "ProfileView")
                            ButtonMyProfile.Style = (Style)FindResource("Button.sidetab");
                        break;
                }
            }
        }
    }
}
