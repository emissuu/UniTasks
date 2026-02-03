using Data.Models;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Services.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UI.Views
{
    /// <summary>
    /// Interaction logic for TeamsView.xaml
    /// </summary>
    public partial class TeamsView : UserControl
    {
        private IServiceProvider _services;
        private User _activeUser;
        private TeamDetails? _editedTeam;
        public Visibility AdvancedEdit { get; set; } = Visibility.Visible;
        public TeamsView(User user, IServiceProvider services)
        {
            _activeUser = user;
            _services = services;
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            if (_activeUser.RoleId != 1)
            {
                ButtonCreateTeam.Visibility = Visibility.Collapsed;
                ButtonRemoveTeam.Visibility = Visibility.Collapsed;
            }
            Update();
        }

        public void Update()
        {
            var teams = _services.GetService<ITeamService>().GetAllTeamDetails();
            ItemsControlTeams.Items.Clear();
            foreach (var team in teams)
            {
                ItemsControlTeams.Items.Add(team);
            }
        }

        private void ButtonAddTeam_Click(object sender, RoutedEventArgs e)
        {
            ButtonSaveChanges.Content = "Create Team";
            SideEditTeamDetails.Visibility = Visibility.Visible;
            _editedTeam = null;
        }

        private void ButtonRemoveSelected_Click(object sender, RoutedEventArgs e)
        {
            var teams = ItemsControlTeams.Items
                .Cast<TeamDetails>()
                .ToList()
                .Where(td => td.IsChecked == true);
            var result = MessageBox.Show($"Are you sure you want to remove {teams.Count()} teams?", "TeamTask", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
                _services.GetService<ITeamService>().Remove(teams.Select(td => td.Id).ToArray(), _activeUser.Id);
            Update();
        }

        private void ButtonEditTeamDetails_Click(object sender, RoutedEventArgs e)
        {
            if (_activeUser.RoleId != 1)
            {
                MessageBox.Show("You cannot edit team details!", "TeamTask", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            var teamDetails = (sender as Button).DataContext as TeamDetails;
            ButtonSaveChanges.Content = "Save Changes";
            TextBoxTeamName.Text = teamDetails.Name;
            SideEditTeamDetails.Visibility = Visibility.Visible;
            _editedTeam = teamDetails;
        }

        private void ButtonSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            var teamName = TextBoxTeamName.Text;
            if (String.IsNullOrWhiteSpace(teamName))
            {
                TextBlockWrongUserName.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                TextBlockWrongUserName.Visibility = Visibility.Hidden;
            }
            if (_editedTeam == null)
            {
                _services.GetService<ITeamService>().Add(new Team()
                {
                    Name = teamName,
                    CreatedById = _activeUser.Id
                }, _activeUser.Id);
            }
            else
            {
                var team = _services.GetService<ITeamService>().GetById(_editedTeam.Id);
                team.Name = teamName;
                _services.GetService<ITeamService>().Update(team, _activeUser.Id);
            }
            Update();
            // Close the side panel
            TextBoxTeamName.Text = String.Empty;
            SideEditTeamDetails.Visibility = Visibility.Hidden;
        }

        private void ButtonEditTeamParticipants_Click(object sender, RoutedEventArgs e)
        {
            if (_activeUser.RoleId != 1)
            {
                MessageBox.Show("You cannot edit team participants!", "TeamTask", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            _editedTeam = (sender as Button).DataContext as TeamDetails;
            var userDetails = _services.GetService<IUserService>().GetAllUserDetails()
                .OrderBy(u => u.Role.Id)
                .ThenBy(u => u.UserName)
                .ToList();
            for (int i = 0; i < userDetails.Count(); i++)
            {
                if (_editedTeam.TeamUsers.Any(tu => tu.UserId == userDetails[i].Id))
                {
                    userDetails[i].Selection = true;
                }
            }
            ItemsControlParticipants.Items.Clear();
            foreach (var user in userDetails)
            {
                ItemsControlParticipants.Items.Add(user);
            }
            SideEditTeamParticipants.Visibility = Visibility.Visible;
        }

        private void TeamDetailsSidePanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBoxTeamName.Text = String.Empty;
            SideEditTeamDetails.Visibility = Visibility.Hidden;
        }

        private void TeamParticipantsSidePanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SideEditTeamParticipants.Visibility = Visibility.Hidden;
        }

        private void ButtonSaveParticipants_Click(object sender, RoutedEventArgs e)
        {
            var users = ItemsControlParticipants.Items
                .Cast<UserDetails>()
                .ToList()
                .Where(ud => ud.IsChecked == true);
            _services.GetService<ITeamService>().AddTeamUsers(users
                .Select(u => new TeamUser()
                {
                    UserId = u.Id,
                    TeamId = _editedTeam.Id
                }).ToList());
            SideEditTeamParticipants.Visibility = Visibility.Hidden;
        }
    }
}
