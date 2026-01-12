using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Data.Models;
using Services.Models;
using Services.Storages;
using MainWindow = UI2.Windows;

namespace UI2.Views;

public partial class HomeView : UserControl
{
    private ServiceStorage _serviceStorage;
    private Event? _selectedEvent;
    private Worker? _selectedWorker;
    public ObservableCollection<Event> Events { get; }
    public ObservableCollection<Worker> Workers { get; }
    public HomeView(ref ServiceStorage serviceStorage)
    {
        _serviceStorage = serviceStorage;
        InitializeComponent();
        Workers = new ObservableCollection<Worker>(_serviceStorage._workerServ.GetAllPeople());
        Events = new ObservableCollection<Event>(_serviceStorage._eventServ.GetAllEventsInAWeek());
        DataContext = this;
    }
    public Event? SelectedEvent
    {
        get => _selectedEvent;
        set => _selectedEvent = value;
    }
    public Worker? SelectedWorker
    {
        get => _selectedWorker;
        set => _selectedWorker = value;
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
    private void WorkersListBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (SelectedWorker != null)
        {
            MainWindow.MainWindow.Instance.ContentArea.Content = new PeopleView(ref _serviceStorage);
        }
    }
}