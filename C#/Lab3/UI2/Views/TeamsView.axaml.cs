using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Data.Models;
using Services.Storages;
using static Azure.Core.HttpHeader;

namespace UI2.Views;

public partial class TeamsView : UserControl
{
    private ServiceStorage _serviceStorage;
    public ObservableCollection<Team> Teams { get; }
    private Team? _selectedTeam;
    public TeamsView(ref ServiceStorage serviceStorage)
    {
        _serviceStorage = serviceStorage;
        DataContext = this;
        Teams = new ObservableCollection<Team>(_serviceStorage._teamServ.GetAll());
        InitializeComponent();
    }
    public Team? SelectedTeam
    {
        get => _selectedTeam;
        set => _selectedTeam = value;
    }

    private void SaveTeamButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
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
    }

    private void AddTeamButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _serviceStorage._teamServ.Add(new Team()
        {
            Name = TextBoxName.Text,
            HandColor = TextBoxColor.Text == "" ? null : TextBoxColor.Text,
            Notes = TextBoxNotes.Text == "" ? null : TextBoxNotes.Text,
        });
    }
    private void RemoveTeamButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_selectedTeam != null)
        {
            _serviceStorage._teamServ.Delete(_selectedTeam.Id);
        }
    }

    private void DataGrid_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        TextBoxName.Text = SelectedTeam?.Name ?? string.Empty;
        TextBoxColor.Text = SelectedTeam?.HandColor ?? string.Empty;
        TextBoxNotes.Text = SelectedTeam?.Notes ?? string.Empty;
    }
}