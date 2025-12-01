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
    public ObservableCollection<Zone> Zones { get; }
    private Zone? _selectedZone;
    public ZonesView(ref ServiceStorage serviceStorage)
    {
        _serviceStorage = serviceStorage;
        DataContext = this;
        Zones = new ObservableCollection<Zone>(_serviceStorage._zoneServ.GetAll());
        InitializeComponent();
    }
    public Zone? SelectedZone
    {
        get => _selectedZone;
        set => _selectedZone = value;
    }

    private void SaveZoneButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
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
    }

    private void AddZoneButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _serviceStorage._zoneServ.Add(new Zone()
        {
            Name = TextBoxName.Text,
            Type = TextBoxType.Text == "" ? null : TextBoxType.Text,
            Location = TextBoxLocation.Text == "" ? null : TextBoxLocation.Text,
        });
    }
    private void RemoveZoneButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_selectedZone != null)
        {
            _serviceStorage._zoneServ.Delete(_selectedZone.Id);
        }
    }

    private void DataGrid_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        TextBoxName.Text = SelectedZone?.Name ?? string.Empty;
        TextBoxType.Text = SelectedZone?.Type ?? string.Empty;
        TextBoxLocation.Text = SelectedZone?.Location ?? string.Empty;
    }
}