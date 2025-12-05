using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Data.Models;
using Services.Storages;

namespace UI2.Views;

public partial class MainView : UserControl
{
    private ServiceStorage _serviceStorage;
    private int _eventId;
    public ObservableCollection<EventBlock> EventBlocks { get; }
    private EventBlock? SelectedEventBlock;
    public MainView(ref ServiceStorage serviceStorage, int eventId)
    {
        _serviceStorage = serviceStorage;
        _eventId = eventId;
        //EventBlocks = new ObservableCollection<EventBlock>(_serviceStorage._eventBlockServ.GetByEventId(_eventId));
        InitializeComponent();
        TextBlockEventTitle.Text = _serviceStorage._eventServ.GetById(_eventId).Name;
    }
}