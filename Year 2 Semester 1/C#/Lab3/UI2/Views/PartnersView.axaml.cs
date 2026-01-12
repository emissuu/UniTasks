using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Data.Models;
using Services.Storages;

namespace UI2.Views;

public partial class PartnersView : UserControl
{
    private ServiceStorage _serviceStorage;
    public ObservableCollection<Partner> Partners { get; set; }
    private Partner? _selectedPartner;
    public PartnersView(ref ServiceStorage serviceStorage)
    {
        _serviceStorage = serviceStorage;
        InitializeComponent();
        Partners = new ObservableCollection<Partner>(_serviceStorage._partnerServ.GetAll());
        DataContext = this;
    }
    public Partner? SelectedPartner
    {
        get => _selectedPartner;
        set => _selectedPartner = value;
    }
    private void UpdateGrid()
    {
        Partners.Clear();
        foreach (var partner in _serviceStorage._partnerServ.GetAll())
            Partners.Add(partner);
    }

    private void SaveButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_selectedPartner != null)
        {
            _serviceStorage._partnerServ.Update(new Partner()
            {
                Id = _selectedPartner.Id,
                Name = TextBoxName.Text,
                ContactNumber = TextBoxNumber.Text == "" ? null : TextBoxNumber.Text,
                Description = TextBoxDescription.Text == "" ? null : TextBoxDescription.Text,
            });
        }
        UpdateGrid();
    }

    private void AddButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _serviceStorage._partnerServ.Add(new Partner()
        {
            Name = TextBoxName.Text,
            ContactNumber = TextBoxNumber.Text == "" ? null : TextBoxNumber.Text,
            Description = TextBoxDescription.Text == "" ? null : TextBoxDescription.Text,
        });
        UpdateGrid();
    }
    private void RemoveButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_selectedPartner != null)
        {
            _serviceStorage._partnerServ.Delete(_selectedPartner.Id);
        }
        UpdateGrid();
    }
    private void ClearButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _selectedPartner = null;
        TextBoxName.Text = string.Empty;
        TextBoxNumber.Text = string.Empty;
        TextBoxDescription.Text = string.Empty;
    }

    private void DataGrid_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        TextBoxName.Text = SelectedPartner?.Name ?? string.Empty;
        TextBoxNumber.Text = SelectedPartner?.ContactNumber ?? string.Empty;
        TextBoxDescription.Text = SelectedPartner?.Description ?? string.Empty;
    }
}