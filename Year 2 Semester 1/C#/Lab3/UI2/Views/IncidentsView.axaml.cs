using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Data.Models;
using Services.Storages;

namespace UI2.Views;

public partial class IncidentsView : UserControl
{
    private ServiceStorage _serviceStorage;
    private int _eventId;
    public ObservableCollection<Incident> Incidents { get; set; }
    private Incident? _selectedIncident;
    public IncidentsView(ref ServiceStorage serviceStorage, int eventId, int? incidentId)
    {
        _serviceStorage = serviceStorage;
        _eventId = eventId;
        InitializeComponent();
        Incidents = new ObservableCollection<Incident>(_serviceStorage._incidentServ.GetByEventId(_eventId));
        DataContext = this;
        foreach (var ticket in _serviceStorage._ticketServ.GetAllNamesByEventId(_eventId))
            ComboBoxTicket.Items.Add(ticket);
        ComboBoxTicket.SelectedIndex = 0;
    }
    public Incident? SelectedIncident
    {
        get => _selectedIncident;
        set => _selectedIncident = value;
    }
    private void UpdateGrid()
    {
        Incidents.Clear();
        foreach (var inc in _serviceStorage._incidentServ.GetByEventId(_eventId))
            Incidents.Add(inc);
    }
    private void ClearButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        SelectedIncident = null;
        ComboBoxTicket.SelectedIndex = 0;
        TextBoxType.Text = string.Empty;
        TextBoxDescription.Text = string.Empty;
        DatePickerHappenedAt.SelectedTime = null;
        CheckBoxIsResolved.IsChecked = false;
    }
    private void SaveButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_selectedIncident != null)
        {
            DateTime? happenedAt = _serviceStorage._eventServ.GetById(_eventId).Date + DatePickerHappenedAt.SelectedTime;
            bool isResolved = CheckBoxIsResolved.IsChecked ?? false; 
            _serviceStorage._incidentServ.Update(new Incident()
            {
                Id = _selectedIncident.Id,
                TicketId = _serviceStorage._ticketServ.GetIdByQrCode(ComboBoxTicket.SelectedItem.ToString()),
                Type = TextBoxType.Text,
                Description = TextBoxDescription.Text,
                HappenedAt = happenedAt,
                IsResolved = isResolved
            });
        }
        UpdateGrid();
    }
    private void AddButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DateTime? happenedAt = _serviceStorage._eventServ.GetById(_eventId).Date + DatePickerHappenedAt.SelectedTime;
        bool isResolved = CheckBoxIsResolved.IsChecked ?? false;
        _serviceStorage._incidentServ.Add(new Incident()
        {
            TicketId = _serviceStorage._ticketServ.GetIdByQrCode(ComboBoxTicket.SelectedItem.ToString()),
            Type = TextBoxType.Text,
            Description = TextBoxDescription.Text,
            HappenedAt = happenedAt,
            IsResolved = isResolved
        });
        UpdateGrid();
    }
    private void RemoveButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_selectedIncident != null)
        {
            _serviceStorage._incidentServ.Delete(_selectedIncident.Id);
            UpdateGrid();
        }
    }
    private void DataGrid_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (_selectedIncident != null)
        {
            ComboBoxTicket.SelectedItem = _selectedIncident?.Ticket?.QrCode ?? _serviceStorage._ticketServ.GetAllNamesByEventId(_eventId).ToList()[0];
            TextBoxType.Text = _selectedIncident?.Type ?? string.Empty;
            TextBoxDescription.Text = _selectedIncident?.Description ?? string.Empty;
            DatePickerHappenedAt.SelectedTime = _selectedIncident?.HappenedAt?.TimeOfDay;
            CheckBoxIsResolved.IsChecked = _selectedIncident?.IsResolved ?? false;
        }
    }
}