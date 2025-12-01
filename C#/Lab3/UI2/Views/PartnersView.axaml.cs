using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Data.Models;
using Services.Storages;

namespace UI2.Views;

public partial class PartnersView : UserControl
{
    private ServiceStorage _serviceStorage;
    public ObservableCollection<Partner> Partners { get; }
    private Partner? _selectedPartner;
    public PartnersView(ref ServiceStorage serviceStorage)
    {
        _serviceStorage = serviceStorage;
        DataContext = this;
        Partners = new ObservableCollection<Partner>(_serviceStorage._partnerServ.GetAll());
        InitializeComponent();
    }
    public Partner? SelectedPartner
    {
        get => _selectedPartner;
        set => _selectedPartner = value;
    }

    private void SavePartnerButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
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
    }

    private void AddPartnerButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _serviceStorage._partnerServ.Add(new Partner()
        {
            Name = TextBoxName.Text,
            ContactNumber = TextBoxNumber.Text == "" ? null : TextBoxNumber.Text,
            Description = TextBoxDescription.Text == "" ? null : TextBoxDescription.Text,
        });
    }
    private void RemovePartnerButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_selectedPartner != null)
        {
            _serviceStorage._partnerServ.Delete(_selectedPartner.Id);
        }
    }

    private void DataGrid_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        TextBoxName.Text = SelectedPartner?.Name ?? string.Empty;
        TextBoxNumber.Text = SelectedPartner?.ContactNumber ?? string.Empty;
        TextBoxDescription.Text = SelectedPartner?.Description ?? string.Empty;
    }
}