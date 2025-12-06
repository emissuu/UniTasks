using Avalonia.Controls;
using Services.Storages;
using UI2.Views;

namespace UI2.Windows
{
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }
        ServiceStorage _serviceStorage;

        public MainWindow(ref ServiceStorage serviceStorage)
        {
            Instance = this;
            InitializeComponent();
            _serviceStorage = serviceStorage;
            ContentArea.Content = new HomeView(ref _serviceStorage);
        }

        private void ExpandSidePanel_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SidePanel.IsPaneOpen = !SidePanel.IsPaneOpen;
        }

        private void Home_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (ContentArea.Content is HomeView) return;
            ContentArea.Content = new HomeView(ref _serviceStorage);
        }
        private void Events_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (ContentArea.Content is EventsView) return;
            ContentArea.Content = new EventsView(ref _serviceStorage);
        }
        private void People_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (ContentArea.Content is PeopleView) return;
            ContentArea.Content = new PeopleView(ref _serviceStorage);
        }
        private void Teams_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (ContentArea.Content is TeamsView) return;
            ContentArea.Content = new TeamsView(ref _serviceStorage);
        }
        private void Zones_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (ContentArea.Content is ZonesView) return;
            ContentArea.Content = new ZonesView(ref _serviceStorage);
        }
        private void Partners_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (ContentArea.Content is PartnersView) return;
            ContentArea.Content = new PartnersView(ref _serviceStorage);
        }
    }
}