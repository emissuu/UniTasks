using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Services.Storages;
using UI2.Views;

namespace UI2.Windows;

public partial class Event : Window
{
    private ServiceStorage _serviceStorage;
    private int _eventId;
    public Event(ref ServiceStorage serviceStorage, int eventId)
    {
        _serviceStorage = serviceStorage;
        _eventId = eventId;
        InitializeComponent();
        Title = _serviceStorage._eventServ.GetById(_eventId).Name;
        ContentArea.Content = new MainView(ref _serviceStorage, _eventId);
    }
    private void ExpandSidePanel_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        SidePanel.IsPaneOpen = !SidePanel.IsPaneOpen;
    }
    private void Main_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (ContentArea.Content is MainView) return;
        ContentArea.Content = new MainView(ref _serviceStorage, _eventId);
    }
    private void EventBlocks_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (ContentArea.Content is EventBlocksView) return;
        ContentArea.Content = new EventBlocksView(ref _serviceStorage, _eventId, null);
    }
    private void ZoneActivations_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (ContentArea.Content is ZoneActivationsView) return;
        ContentArea.Content = new ZoneActivationsView(ref _serviceStorage, _eventId);
    }
    private void Visitors_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (ContentArea.Content is VisitorsView) return;
        ContentArea.Content = new VisitorsView(ref _serviceStorage, _eventId);
    }
    private void WorkerShifts_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (ContentArea.Content is WorkerShiftsView) return;
        ContentArea.Content = new WorkerShiftsView(ref _serviceStorage, _eventId);
    }
    private void Incidents_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (ContentArea.Content is IncidentsView) return;
        ContentArea.Content = new IncidentsView(ref _serviceStorage, _eventId, null);
    }
}