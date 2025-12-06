using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Data.Models;
using Services.Storages;

namespace UI2.Views;

public partial class EventsView : UserControl
{
    private ServiceStorage _serviceStorage;
    public ObservableCollection<Event> Events { get; }
    private Event? _selectedEvent;
    public EventsView(ref ServiceStorage serviceStorage)
    {
        _serviceStorage = serviceStorage;
        InitializeComponent();
        Events = new ObservableCollection<Event>(_serviceStorage._eventServ.GetAll());
        DataContext = this;
        foreach (var adminName in _serviceStorage._adminServ.GetAllNames())
        {
            ComboBoxAdmin.Items.Add(adminName);
        }
        ComboBoxAdmin.SelectedIndex = 0;
    }
    public Event? SelectedEvent
    {
        get => _selectedEvent;
        set => _selectedEvent = value;
    }
    private void UpdateGrid()
    {
        Events.Clear();
        foreach (var ev in _serviceStorage._eventServ.GetAll())
            Events.Add(ev);
    }
    private void ClearButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _selectedEvent = null;
        TextBoxName.Text = string.Empty;
        DatePickerDate.SelectedDate = null;
        TextBoxLocation.Text = string.Empty;
        ComboBoxAdmin.SelectedIndex = 0;
        TextBoxDescription.Text = string.Empty;
    }
    private void SaveButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_selectedEvent != null)
        {
            _serviceStorage._eventServ.Update(new Event()
            {
                Id = _selectedEvent.Id,
                Name = TextBoxName.Text,
                Date = DatePickerDate.SelectedDate?.Date,
                Location = TextBoxLocation.Text ?? null,
                Description = TextBoxDescription.Text ?? null,
                AdministratorId = _serviceStorage._adminServ.GetIdByName(ComboBoxAdmin.SelectedItem?.ToString() ?? string.Empty),
            });
        }
        UpdateGrid();
    }
    private void AddButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _serviceStorage._eventServ.Add(new Event()
        {
            Name = TextBoxName.Text,
            Date = DatePickerDate.SelectedDate?.Date,
            Location = TextBoxLocation.Text ?? null,
            Description = TextBoxDescription.Text ?? null,
            AdministratorId = _serviceStorage._adminServ.GetIdByName(ComboBoxAdmin.SelectedItem?.ToString() ?? string.Empty),
        });
        UpdateGrid();
    }
    private void RemoveButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_selectedEvent != null)
        {
            _serviceStorage._eventServ.Delete(_selectedEvent.Id);
        }
        UpdateGrid();
    }
    private void EditButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var selectedEvent = (sender as Button)?.DataContext as Event;
        var eventWindow = new Windows.Event(ref _serviceStorage, selectedEvent.Id);
        eventWindow.Show();
    }
    private void DataGrid_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        TextBoxName.Text = _selectedEvent?.Name ?? string.Empty;
        DatePickerDate.SelectedDate = _selectedEvent?.Date != null ? new DateTimeOffset((DateTime)_selectedEvent.Date) : null;
        TextBoxLocation.Text = _selectedEvent?.Location ?? string.Empty;
        ComboBoxAdmin.SelectedItem = _selectedEvent?.Administrator?.Person?.Name ?? _serviceStorage._adminServ.GetAllNames().ToList()[0];
        TextBoxDescription.Text = _selectedEvent?.Description ?? string.Empty;
    }
}