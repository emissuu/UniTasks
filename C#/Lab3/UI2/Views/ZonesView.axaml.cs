using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Data.Models;
using Services.Storages;

namespace UI2.Views;

public partial class ZonesView : UserControl
{
    private ServiceStorage _serviceStorage;
    public ObservableCollection<Zone> Zones { get; set; }
    private Zone? _selectedZone;
    public ZonesView(ref ServiceStorage serviceStorage)
    {
        _serviceStorage = serviceStorage;
        InitializeComponent();
        Zones = new ObservableCollection<Zone>(_serviceStorage._zoneServ.GetAll());
        DataContext = this;
    }
    public Zone? SelectedZone
    {
        get => _selectedZone;
        set => _selectedZone = value;
    }
    private void UpdateGrid()
    {
        Zones.Clear();
        foreach (var zone in _serviceStorage._zoneServ.GetAll())
            Zones.Add(zone);
    }
    private void ClearButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _selectedZone = null;
        TextBoxName.Text = string.Empty;
        TextBoxType.Text = string.Empty;
        TextBoxLocation.Text = string.Empty;
    }
    private void SaveButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_selectedZone != null)
        {
            _serviceStorage._zoneServ.Update(new Zone()
            {
                Id = _selectedZone.Id,
                Name = TextBoxName.Text,
                Type = TextBoxType.Text == "" ? null : TextBoxType.Text,
                Location = TextBoxLocation.Text == "" ? null : TextBoxLocation.Text,
            });
        }
        UpdateGrid();
    }

    private void AddButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _serviceStorage._zoneServ.Add(new Zone()
        {
            Name = TextBoxName.Text,
            Type = TextBoxType.Text == "" ? null : TextBoxType.Text,
            Location = TextBoxLocation.Text == "" ? null : TextBoxLocation.Text,
        });
        UpdateGrid();
    }
    private void RemoveButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_selectedZone != null)
        {
            _serviceStorage._zoneServ.Delete(_selectedZone.Id);
        }
        UpdateGrid();
    }

    private void DataGrid_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        TextBoxName.Text = SelectedZone?.Name ?? string.Empty;
        TextBoxType.Text = SelectedZone?.Type ?? string.Empty;
        TextBoxLocation.Text = SelectedZone?.Location ?? string.Empty;
    }
}