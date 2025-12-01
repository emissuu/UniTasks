using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
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
        DataContext = this;
        Events = new ObservableCollection<Event>(_serviceStorage._eventServ.GetAll());
        InitializeComponent();
    }
    public Event? SelectedEvent
    {
        get => _selectedEvent;
        set
        {
            if (value != null)
            {
                var eventWindow = new Windows.Event(ref _serviceStorage, value.Id);
                eventWindow.Show();
            }
        }
    }
}