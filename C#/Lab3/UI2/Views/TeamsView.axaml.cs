using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Data.Models;
using Services.Storages;

namespace UI2.Views;

public partial class TeamsView : UserControl
{
    private ServiceStorage _serviceStorage;
    public ObservableCollection<Team> Teams { get; set; }
    private Team? _selectedTeam;
    public TeamsView(ref ServiceStorage serviceStorage)
    {
        _serviceStorage = serviceStorage;
        InitializeComponent(); 
        Teams = new ObservableCollection<Team>(_serviceStorage._teamServ.GetAll());
        DataContext = this;
    }
    public Team? SelectedTeam
    {
        get => _selectedTeam;
        set => _selectedTeam = value;
    }
    private void UpdateGrid()
    {
        Teams.Clear();
        foreach (var team in _serviceStorage._teamServ.GetAll())
            Teams.Add(team);
    }
    private void ClearButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _selectedTeam = null;
        TextBoxName.Text = string.Empty;
        TextBoxColor.Text = string.Empty;
        TextBoxNotes.Text = string.Empty;
    }

    private void SaveButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_selectedTeam != null)
        {
            _serviceStorage._teamServ.Update(new Team()
            {
                Id = _selectedTeam.Id,
                Name = TextBoxName.Text,
                HandColor = TextBoxColor.Text == "" ? null : TextBoxColor.Text,
                Notes = TextBoxNotes.Text == "" ? null : TextBoxNotes.Text,
            });
        }
        UpdateGrid();
    }

    private void AddButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _serviceStorage._teamServ.Add(new Team()
        {
            Name = TextBoxName.Text,
            HandColor = TextBoxColor.Text == "" ? null : TextBoxColor.Text,
            Notes = TextBoxNotes.Text == "" ? null : TextBoxNotes.Text,
        });
        UpdateGrid();
    }
    private void RemoveButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_selectedTeam != null)
        {
            _serviceStorage._teamServ.Delete(_selectedTeam.Id);
        }
        UpdateGrid();
    }

    private void DataGrid_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        TextBoxName.Text = SelectedTeam?.Name ?? string.Empty;
        TextBoxColor.Text = SelectedTeam?.HandColor ?? string.Empty;
        TextBoxNotes.Text = SelectedTeam?.Notes ?? string.Empty;
    }
}