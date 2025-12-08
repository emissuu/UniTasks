using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Data.Models;
using Services.Storages;
using UI2.Windows;
using EventWindow = UI2.Windows.Event;

namespace UI2.Views;

public partial class MainView : UserControl
{
    private ServiceStorage _serviceStorage;
    private int _eventId;
    public ObservableCollection<EventBlock> EventBlocks { get; }
    public ObservableCollection<Incident> Incidents { get; }
    private EventBlock? _selectedEventBlock;
    private Incident? _selectedIncident;
    public MainView(ref ServiceStorage serviceStorage, int eventId)
    {
        _serviceStorage = serviceStorage;
        _eventId = eventId;
        InitializeComponent();
        EventBlocks = new ObservableCollection<EventBlock>(_serviceStorage._eventBlockServ.GetByEventId(_eventId));
        Incidents = new ObservableCollection<Incident>(_serviceStorage._incidentServ.GetByEventId(_eventId));
        DataContext = this;
        TextBlockEventTitle.Text = _serviceStorage._eventServ.GetById(_eventId).Name;
    }
    public EventBlock SelectedEventBlock
    {
        get => _selectedEventBlock;
        set => _selectedEventBlock = value;
    }
    public Incident SelectedIncident
    {
        get => _selectedIncident;
        set => _selectedIncident = value;
    }
    private void ListBoxEventBlocks_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (_selectedEventBlock != null)
        {
            EventWindow.Instance.ContentArea.Content = new EventBlocksView(ref _serviceStorage, _eventId, _selectedEventBlock.Id);
        }
    } 
    private void ListBoxIncidents_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (_selectedIncident != null)
        {
            EventWindow.Instance.ContentArea.Content = new IncidentsView(ref _serviceStorage, _eventId, _selectedIncident.Id);
        }
    }
}