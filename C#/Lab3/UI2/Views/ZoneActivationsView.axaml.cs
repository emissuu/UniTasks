using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Services.Storages;

namespace UI2.Views;

public partial class ZoneActivationsView : UserControl
{
    private ServiceStorage _serviceStorage;
    private int _eventId;
    public ZoneActivationsView(ref ServiceStorage serviceStorage, int eventId)
    {
        _serviceStorage = serviceStorage;
        _eventId = eventId;
        InitializeComponent();
    }
}