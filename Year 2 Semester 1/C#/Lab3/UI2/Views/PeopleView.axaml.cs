using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using Avalonia;
using Avalonia.Controls;
using Data.Models;
using Services.Models;
using Services.Storages;

namespace UI2.Views;

public partial class PeopleView : UserControl
{
    private ServiceStorage _serviceStorage;
    public ObservableCollection<PersonRole> People { get; set; }
    private PersonRole? _selectedPerson;
    public PeopleView(ref ServiceStorage serviceStorage)
    {
        _serviceStorage = serviceStorage;
        DataContext = this;
        People = new ObservableCollection<PersonRole>(_serviceStorage._personServ.GetAllPersonRole());
        InitializeComponent();
        foreach (var teamName in _serviceStorage._teamServ.GetAllNames())
            TextBoxGuestTeam.Items.Add(teamName);
        ComboBoxRole.SelectedIndex = 0;
    }
    public PersonRole? SelectedPerson
    {
        get => _selectedPerson;
        set => _selectedPerson = value;
    }

    private void UpdateGrid()
    {
        People.Clear();
        foreach (var person in _serviceStorage._personServ.GetAllPersonRole())
            People.Add(person);
    }

    private void SavePersonButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_selectedPerson != null)
        {
            _serviceStorage._personServ.Update(new Person()
            {
                Id = _selectedPerson.Id,
                Name = TextBoxName.Text,
                ContactNumber = TextBoxNumber.Text == "" ? null : TextBoxNumber.Text
            });
            try
            {
                switch (ComboBoxRole.SelectedIndex)
                {
                    case 0:
                        if (_selectedPerson.Administrator != null)
                            _serviceStorage._adminServ.Delete(_selectedPerson.Administrator.Id);
                        if (_selectedPerson.Worker != null)
                            _serviceStorage._workerServ.Delete(_selectedPerson.Worker.Id);
                        if (_selectedPerson.Guest != null)
                            _serviceStorage._teamMemberServ.Delete(_selectedPerson.Guest.Id);
                        break;
                    case 1:
                        if (_selectedPerson.Administrator != null)
                            _serviceStorage._adminServ.Delete(_selectedPerson.Administrator.Id);
                        if (_selectedPerson.Worker != null)
                            _serviceStorage._workerServ.Delete(_selectedPerson.Worker.Id);
                        if (_selectedPerson.Guest != null)
                        {
                            _serviceStorage._teamMemberServ.Update(new TeamMember()
                            {
                                Id = _selectedPerson.Guest.Id,
                                PersonId = _selectedPerson.Id,
                                Role = TextBoxGuestRole.Text,
                                Team = _serviceStorage._teamServ.GetAll().FirstOrDefault(t => t.Name == TextBoxGuestTeam.SelectedItem.ToString())
                            });
                        }
                        else
                        {
                            _serviceStorage._teamMemberServ.Add(new TeamMember()
                            {
                                PersonId = _selectedPerson.Id,
                                Role = TextBoxGuestRole.Text,
                                Team = _serviceStorage._teamServ.GetAll().FirstOrDefault(t => t.Name == TextBoxGuestTeam.SelectedItem.ToString())
                            });
                        }
                        break;
                    case 2:
                        if (_selectedPerson.Administrator != null)
                            _serviceStorage._adminServ.Delete(_selectedPerson.Administrator.Id);
                        if (_selectedPerson.Guest != null)
                            _serviceStorage._teamMemberServ.Delete(_selectedPerson.Guest.Id);
                        if (_selectedPerson.Worker != null)
                        {
                            _serviceStorage._workerServ.Update(new Worker()
                            {
                                Id = _selectedPerson.Worker.Id,
                                PersonId = _selectedPerson.Id,
                                Role = TextBoxWorkerRole.Text,
                                Salary = int.Parse(TextBoxWorkerSalary.Text)
                            });
                        }
                        else
                        {
                            _serviceStorage._workerServ.Add(new Worker()
                            {
                                PersonId = _selectedPerson.Id,
                                Role = TextBoxWorkerRole.Text,
                                Salary = int.Parse(TextBoxWorkerSalary.Text)
                            });
                        }
                        break;
                    case 3:
                        if (_selectedPerson.Worker != null)
                            _serviceStorage._workerServ.Delete(_selectedPerson.Worker.Id);
                        if (_selectedPerson.Guest != null)
                            _serviceStorage._teamMemberServ.Delete(_selectedPerson.Guest.Id);
                        if (_selectedPerson.Administrator != null)
                        {
                            _serviceStorage._adminServ.Update(new Administrator()
                            {
                                Id = _selectedPerson.Administrator.Id,
                                PersonId = _selectedPerson.Id,
                                Salary = int.Parse(TextBoxAdministratorSalary.Text)
                            });
                        }
                        else
                        {
                            _serviceStorage._adminServ.Add(new Administrator()
                            {
                                PersonId = _selectedPerson.Id,
                                Salary = int.Parse(TextBoxAdministratorSalary.Text)
                            });
                        }
                        break;
                }
            }
            catch
            {
            }
        }
        UpdateGrid();
    }

    private void AddPersonButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _serviceStorage._personServ.Add(new Person()
        {
            Name = TextBoxName.Text,
            ContactNumber = TextBoxNumber.Text == "" ? null : TextBoxNumber.Text
        });
        if (ComboBoxRole.SelectedIndex != 0)
        {
            var addedPerson = _serviceStorage._personServ.GetAllPersonRole().Last();
            try
            {
                switch (ComboBoxRole.SelectedIndex)
                {
                    case 1:
                        _serviceStorage._teamMemberServ.Add(new TeamMember()
                        {
                            PersonId = addedPerson.Id,
                            Role = TextBoxGuestRole.Text,
                            Team = _serviceStorage._teamServ.GetAll().FirstOrDefault(t => t.Name == TextBoxGuestTeam.SelectedItem.ToString())
                        });
                        break;
                    case 2:
                        _serviceStorage._workerServ.Add(new Worker()
                        {
                            PersonId = addedPerson.Id,
                            Role = TextBoxWorkerRole.Text,
                            Salary = int.Parse(TextBoxWorkerSalary.Text)
                        });
                        break;
                    case 3:
                        _serviceStorage._adminServ.Add(new Administrator()
                        {
                            PersonId = addedPerson.Id,
                            Salary = int.Parse(TextBoxAdministratorSalary.Text)
                        });
                        break;
                    default:
                        break;
                }
            }
            catch
            {   
            }
        }
        UpdateGrid();
    }
    private void RemovePersonButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_selectedPerson != null)
        {
            _serviceStorage._personServ.Delete(_selectedPerson.Id);
        }
        UpdateGrid();
    }
    private void ClearButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _selectedPerson = null;
        TextBoxName.Text = string.Empty;
        TextBoxNumber.Text = string.Empty;
        ComboBoxRole.SelectedIndex = 0;
        RoleSeparator.IsVisible = false;
        LabelAdministratorSalary.IsVisible = false;
        TextBoxAdministratorSalary.IsVisible = false;
        TextBoxAdministratorSalary.Text = string.Empty;
        LabelWorkerRole.IsVisible = false;
        TextBoxWorkerRole.IsVisible = false;
        TextBoxWorkerRole.Text = string.Empty;
        LabelWorkerSalary.IsVisible = false;
        TextBoxWorkerSalary.IsVisible = false;
        TextBoxWorkerSalary.Text = string.Empty;
        LabelGuestRole.IsVisible = false;
        TextBoxGuestRole.IsVisible = false;
        TextBoxGuestRole.Text = string.Empty;
        LabelGuestTeam.IsVisible = false;
        TextBoxGuestTeam.IsVisible = false;
        TextBoxGuestTeam.SelectedIndex = 0;
    }

    private void DataGrid_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        UpdateRows(false);
    }

    private void ComboBoxRole_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        UpdateRows(true);
    }

    private void UpdateRows(bool combo)
    {
        int selectedRole;
        if (!combo)
        {
            selectedRole = SelectedPerson?.RoleNumber ?? 0;
            TextBoxName.Text = SelectedPerson?.Name ?? string.Empty;
            TextBoxNumber.Text = SelectedPerson?.ContactNumber ?? string.Empty;
            ComboBoxRole.SelectedIndex = selectedRole;
        }
        else
        {
            selectedRole = ComboBoxRole.SelectedIndex;
        }
        switch (selectedRole)
        {
            case 0:
                RoleSeparator.IsVisible = false;
                LabelAdministratorSalary.IsVisible = false;
                TextBoxAdministratorSalary.IsVisible = false;
                LabelWorkerRole.IsVisible = false;
                TextBoxWorkerRole.IsVisible = false;
                LabelWorkerSalary.IsVisible = false;
                TextBoxWorkerSalary.IsVisible = false;
                LabelGuestRole.IsVisible = false;
                TextBoxGuestRole.IsVisible = false;
                LabelGuestTeam.IsVisible = false;
                TextBoxGuestTeam.IsVisible = false;
                break;
            case 1:
                RoleSeparator.IsVisible = true;
                LabelAdministratorSalary.IsVisible = false;
                TextBoxAdministratorSalary.IsVisible = false;
                LabelWorkerRole.IsVisible = false;
                TextBoxWorkerRole.IsVisible = false;
                LabelWorkerSalary.IsVisible = false;
                TextBoxWorkerSalary.IsVisible = false;
                LabelGuestRole.IsVisible = true;
                TextBoxGuestRole.IsVisible = true;
                LabelGuestTeam.IsVisible = true;
                TextBoxGuestTeam.IsVisible = true;
                TextBoxGuestRole.Text = SelectedPerson?.Guest?.Role ?? string.Empty;
                TextBoxGuestTeam.SelectedItem = SelectedPerson?.Guest?.Team?.Name ?? _serviceStorage._teamServ.GetAllNames().ToList()[0];
                break;
            case 2:
                RoleSeparator.IsVisible = true;
                LabelAdministratorSalary.IsVisible = false;
                TextBoxAdministratorSalary.IsVisible = false;
                LabelWorkerRole.IsVisible = true;
                TextBoxWorkerRole.IsVisible = true;
                LabelWorkerSalary.IsVisible = true;
                TextBoxWorkerSalary.IsVisible = true;
                LabelGuestRole.IsVisible = false;
                TextBoxGuestRole.IsVisible = false;
                LabelGuestTeam.IsVisible = false;
                TextBoxGuestTeam.IsVisible = false;
                TextBoxWorkerRole.Text = SelectedPerson?.Worker?.Role ?? string.Empty;
                TextBoxWorkerSalary.Text = SelectedPerson?.Worker?.Salary.ToString() ?? string.Empty;
                break;
            case 3:
                RoleSeparator.IsVisible = true;
                LabelAdministratorSalary.IsVisible = true;
                TextBoxAdministratorSalary.IsVisible = true;
                LabelWorkerRole.IsVisible = false;
                TextBoxWorkerRole.IsVisible = false;
                LabelWorkerSalary.IsVisible = false;
                TextBoxWorkerSalary.IsVisible = false;
                LabelGuestRole.IsVisible = false;
                TextBoxGuestRole.IsVisible = false;
                LabelGuestTeam.IsVisible = false;
                TextBoxGuestTeam.IsVisible = false;
                TextBoxAdministratorSalary.Text = SelectedPerson?.Administrator?.Salary.ToString() ?? string.Empty;
                break;
            default:
                break;
        }
    }
}