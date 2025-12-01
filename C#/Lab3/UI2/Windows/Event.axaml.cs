using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Services.Storages;

namespace UI2.Windows;

public partial class Event : Window
{
    private ServiceStorage _serviceStorage;
    private int _eventId;
    public Event(ref ServiceStorage serviceStorage, int eventId)
    {
        InitializeComponent();
        _serviceStorage = serviceStorage;
        _eventId = eventId;
        Title = _serviceStorage._eventServ.GetById(_eventId).Name;
    }
}