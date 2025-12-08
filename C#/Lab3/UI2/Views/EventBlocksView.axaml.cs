using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Data.Models;
using Services.Storages;

namespace UI2.Views;

public partial class EventBlocksView : UserControl
{
    private ServiceStorage _serviceStorage;
    private int _eventId;
    public ObservableCollection<EventBlock> EventBlocks { get; set; }
    private EventBlock? _selectedEventBlock;
    public ObservableCollection<TeamMember> Participants { get; set; }
    public ObservableCollection<TeamMember> SelectedParticipants { get; set; } = new();
    public EventBlocksView(ref ServiceStorage serviceStorage, int eventId, int? eventBlockId)
    {
        _serviceStorage = serviceStorage;
        _eventId = eventId;
        InitializeComponent();
        EventBlocks = new ObservableCollection<EventBlock>(_serviceStorage._eventBlockServ.GetByEventId(_eventId));
        Participants = new ObservableCollection<TeamMember>(_serviceStorage._teamMemberServ.GetAllPeople());
        DataContext = this;
        foreach (var zoneActivationName in _serviceStorage._zoneActivationServ.GetAllNamesByEventId(_eventId))
            ComboBoxZoneActivation.Items.Add(zoneActivationName);
        ComboBoxZoneActivation.SelectedIndex = 0;
    }
    public EventBlock SelectedEventBlock
    {
        get => _selectedEventBlock;
        set => _selectedEventBlock = value;
    }
    private void UpdateGrid()
    {
        EventBlocks.Clear();
        foreach (var eb in _serviceStorage._eventBlockServ.GetByEventId(_eventId))
            EventBlocks.Add(eb);
    }
    private void ClearButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _selectedEventBlock = null;
        ComboBoxZoneActivation.SelectedIndex = 0;
        TextBoxName.Text = string.Empty;
        TextBoxType.Text = string.Empty;
        DatePickerStartsAt.SelectedTime = null;
        DatePickerEndsAt.SelectedTime = null;
        SelectedParticipants.Clear();
    }
    private void SaveButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_selectedEventBlock != null)
        {
            DateTime? startsAt = _serviceStorage._eventServ.GetById(_eventId).Date + DatePickerStartsAt.SelectedTime;
            DateTime? endsAt = _serviceStorage._eventServ.GetById(_eventId).Date + DatePickerEndsAt.SelectedTime;
            _serviceStorage._eventBlockServ.Update(new EventBlock()
            {
                Id = _selectedEventBlock.Id,
                ZoneActivationId = _serviceStorage._zoneActivationServ.GetIdByNameAndEventId(ComboBoxZoneActivation.SelectedItem?.ToString() ?? string.Empty, _eventId),
                Name = TextBoxName.Text,
                Type = TextBoxType.Text,
                StartsAt = startsAt,
                EndsAt = endsAt,
                TeamMembers = SelectedParticipants
            });
        }
        UpdateGrid();
    }
    private void AddButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DateTime? startsAt = _serviceStorage._eventServ.GetById(_eventId).Date + DatePickerStartsAt.SelectedTime;
        DateTime? endsAt = _serviceStorage._eventServ.GetById(_eventId).Date + DatePickerEndsAt.SelectedTime;
        _serviceStorage._eventBlockServ.Add(new EventBlock()
        {
            ZoneActivationId = _serviceStorage._zoneActivationServ.GetIdByNameAndEventId(ComboBoxZoneActivation.SelectedItem?.ToString() ?? string.Empty, _eventId),
            Name = TextBoxName.Text,
            Type = TextBoxType.Text,
            StartsAt = startsAt,
            EndsAt = endsAt,
            TeamMembers = SelectedParticipants
        });
        UpdateGrid();
    }
    private void RemoveButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_selectedEventBlock != null)
        {
            _serviceStorage._eventBlockServ.Delete(_selectedEventBlock.Id);
            UpdateGrid();
        }
    }
    private void DataGrid_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if(_selectedEventBlock != null)
        {
            TextBoxName.Text = _selectedEventBlock.Name;
            TextBoxType.Text = _selectedEventBlock.Type;
            DatePickerStartsAt.SelectedTime = _selectedEventBlock.StartsAt?.TimeOfDay;
            DatePickerEndsAt.SelectedTime = _selectedEventBlock.EndsAt?.TimeOfDay;
            ComboBoxZoneActivation.SelectedItem = _selectedEventBlock?.ZoneActivation?.Zone?.Name ?? _serviceStorage._zoneActivationServ.GetAllNamesByEventId(_eventId).ToList()[0];
            SelectedParticipants = new ObservableCollection<TeamMember>(_serviceStorage._teamMemberServ.GetByEventBlock(_selectedEventBlock.Id));
        }
    }
    private void ButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        PopupParticipants.IsOpen = !PopupParticipants.IsOpen;
    }
}