using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Data.Models;
using Services.Storages;

namespace UI2.Views;

public partial class ZoneActivationsView : UserControl
{
    private ServiceStorage _serviceStorage;
    private int _eventId;
    public ObservableCollection<ZoneActivation> ZoneActivations { get; set; }
    private ZoneActivation? _selectedZoneActivation;
    public ZoneActivationsView(ref ServiceStorage serviceStorage, int eventId)
    {
        _serviceStorage = serviceStorage;
        _eventId = eventId;
        InitializeComponent();
        ZoneActivations = new ObservableCollection<ZoneActivation>(_serviceStorage._zoneActivationServ.GetByEventId(_eventId));
        DataContext = this;
        foreach (var zoneName in _serviceStorage._zoneServ.GetAllNames())
            ComboBoxZone.Items.Add(zoneName);
        ComboBoxPartner.Items.Add("No partner");
        foreach (var partnerName in _serviceStorage._partnerServ.GetAllNames())
            ComboBoxPartner.Items.Add(partnerName);
        ComboBoxZone.SelectedIndex = 0;
        ComboBoxPartner.SelectedIndex = 0;
    }
    public ZoneActivation SelectedZoneActivation
    {
        get => _selectedZoneActivation;
        set => _selectedZoneActivation = value;
    }
    private void UpdateGrid()
    {
        ZoneActivations.Clear();
        foreach (var za in _serviceStorage._zoneActivationServ.GetByEventId(_eventId))
            ZoneActivations.Add(za);
    }
    private void ClearButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _selectedZoneActivation = null;
        ComboBoxZone.SelectedIndex = 0;
        ComboBoxPartner.SelectedIndex = 0;
        TextBoxNotes.Text = string.Empty;
    }
    private void SaveButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_selectedZoneActivation != null)
        {
            _serviceStorage._zoneActivationServ.Update(new ZoneActivation()
            {
                Id = _selectedZoneActivation.Id,
                EventId = _eventId,
                ZoneId = _serviceStorage._zoneServ.GetIdByName(ComboBoxZone.SelectedItem?.ToString() ?? string.Empty),
                PartnerId = ComboBoxPartner.SelectedIndex == 0 ? null : _serviceStorage._partnerServ.GetIdByName(ComboBoxPartner.SelectedItem?.ToString() ?? string.Empty),
                Notes = TextBoxNotes.Text == "" ? null : TextBoxNotes.Text,
            });
        }
        UpdateGrid();
    }
    private void AddButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _serviceStorage._zoneActivationServ.Add(new ZoneActivation()
        {
            EventId = _eventId,
            ZoneId = _serviceStorage._zoneServ.GetIdByName(ComboBoxZone.SelectedItem?.ToString() ?? string.Empty),
            PartnerId = ComboBoxPartner.SelectedIndex == 0 ? null : _serviceStorage._partnerServ.GetIdByName(ComboBoxPartner.SelectedItem?.ToString() ?? string.Empty),
            Notes = TextBoxNotes.Text == "" ? null : TextBoxNotes.Text,
        });
        UpdateGrid();
    }
    private void RemoveButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_selectedZoneActivation != null)
        {
            _serviceStorage._zoneActivationServ.Delete(_selectedZoneActivation.Id);
        }
        UpdateGrid();
    }
    private void DataGrid_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        ComboBoxZone.SelectedItem = _selectedZoneActivation?.Zone?.Name ?? _serviceStorage._zoneServ.GetAllNames().ToList()[0];
        ComboBoxPartner.SelectedItem = _selectedZoneActivation?.Partner?.Name ?? _serviceStorage._partnerServ.GetAllNames().ToList()[0];
        TextBoxNotes.Text = _selectedZoneActivation?.Notes ?? string.Empty;
    }
}