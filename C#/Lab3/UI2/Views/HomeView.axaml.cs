using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Data.Models;
using Services.Storages;

namespace UI2.Views;

public partial class HomeView : UserControl
{
    private ServiceStorage _serviceStorage;
    private Event? _selectedEvent;
    public ObservableCollection<Event> Events { get; }
    public HomeView(ref ServiceStorage serviceStorage)
    {
        DataContext = this;
        _serviceStorage = serviceStorage;
        Events = new ObservableCollection<Event>(_serviceStorage._eventServ.GetAllEventsInAWeek());
        InitializeComponent();
    }
    public Event? SelectedEvent
    {
        get => _selectedEvent;
        set => _selectedEvent = value;
    }

    private void EventsListBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (SelectedEvent != null)
        {
            var eventWindow = new Windows.Event(ref _serviceStorage, SelectedEvent.Id);
            eventWindow.Show();
            EventsListBox.SelectedItem = null;
        }
    }
}