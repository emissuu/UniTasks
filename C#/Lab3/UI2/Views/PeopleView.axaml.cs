using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Data.Models;
using Services.Models;
using Services.Storages;

namespace UI2.Views;

public partial class PeopleView : UserControl
{
    private ServiceStorage _serviceStorage;
    public ObservableCollection<PersonRole> People { get; }
    private PersonRole? _selectedPerson;
    public PeopleView(ref ServiceStorage serviceStorage)
    {
        _serviceStorage = serviceStorage;
        DataContext = this;
        People = new ObservableCollection<PersonRole>(_serviceStorage._personServ.GetAllPersonRole());
        InitializeComponent();
    }
    public PersonRole? SelectedPerson
    {
        get => _selectedPerson;
        set => _selectedPerson = value;
    }

    private void SavePersonButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_selectedPerson != null)
        {
            _serviceStorage._personServ.Update(new Person()
            {
                Id = _selectedPerson.Id,
                Name = TextBoxName.Text,
                ContactNumber = TextBoxNumber.Text == "" ? null : TextBoxNumber.Text
            });
        }
    }

    private void AddPersonButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _serviceStorage._personServ.Add(new Person()
        {
            Name = TextBoxName.Text,
            ContactNumber = TextBoxNumber.Text == "" ? null : TextBoxNumber.Text
        });
    }
    private void RemovePersonButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (_selectedPerson != null)
        {
            _serviceStorage._personServ.Delete(_selectedPerson.Id);
        }
    }

    private void DataGrid_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        TextBoxName.Text = SelectedPerson?.Name ?? string.Empty;
        TextBoxNumber.Text = SelectedPerson?.ContactNumber ?? string.Empty;
    }
}