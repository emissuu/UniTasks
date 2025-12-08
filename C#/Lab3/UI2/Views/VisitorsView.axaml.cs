using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Data.Models;
using Services.Models;
using Services.Storages;

namespace UI2.Views;

public partial class VisitorsView : UserControl
{
    private ServiceStorage _serviceStorage;
    private int _eventId;
    public ObservableCollection<PersonTicket> Visitors { get; set; }
    private PersonTicket? _selectedVisitor;
    public VisitorsView(ref ServiceStorage serviceStorage, int eventId)
    {
        _serviceStorage = serviceStorage;
        _eventId = eventId;
        InitializeComponent();
        Visitors = new ObservableCollection<PersonTicket>(_serviceStorage._personServ.GetAllPersonTicketByEventId(_eventId));
        DataContext = this;
    }
    public PersonTicket? SelectedVisitor
    {
        get => _selectedVisitor;
        set => _selectedVisitor = value;
    }
    public void UpdateGrid()
    {
        Visitors.Clear();
        foreach (var visitor in _serviceStorage._personServ.GetAllPersonTicketByEventId(_eventId))
            Visitors.Add(visitor);
    }
    private void ClearButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        SelectedVisitor = null;
        TextBoxQrCode.Text = string.Empty;
    }
    private void SaveButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (SelectedVisitor != null && SelectedVisitor.Id != null)
        {
            _serviceStorage._ticketServ.Update(new Ticket()
            {
                Id = (int)SelectedVisitor.Id,
                QrCode = TextBoxQrCode.Text,
                PersonId = SelectedVisitor.PersonId,
                EventId = _eventId,
            });
            UpdateGrid();
        }
    }
    private void AddButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (SelectedVisitor != null)
        {
            _serviceStorage._ticketServ.Add(new Ticket()
            {
                QrCode = TextBoxQrCode.Text,
                PersonId = SelectedVisitor.PersonId,
                EventId = _eventId,
            });
        }
        UpdateGrid();
    }
    private void RemoveButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (SelectedVisitor != null && SelectedVisitor.Id != null)
        {
            _serviceStorage._ticketServ.Delete((int)SelectedVisitor.Id);
            UpdateGrid();
        }
    }
    private void DataGrid_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
            TextBoxQrCode.Text = SelectedVisitor?.QrCode ?? string.Empty;
    }
}