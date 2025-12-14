using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.VisualTree;
using Services.Implementations;
using Services.Models;

namespace UI;

public partial class MainWindow : Window
{
    internal static MainWindow Instance { get; private set; }
    private ServiceStorage _service;
    private ThemeColors theme;
    public ThemeColors ActiveTheme { get { return theme; } set { theme = value; } }
    public MainWindow(ref ServiceStorage serviceStorage)
    {
        Instance = this;
        _service = serviceStorage;
        ActiveTheme = _service._userServ.GetCurrentTheme();
        InitializeComponent();
        DataContext = this;
        ContentArea.Content = new HomeView(ref _service, ref theme);
    }

    private void MinimizeButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }
    private void MaximizeButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
    }
    private void CloseButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }

    private void Border_PointerPressed(object? sender, Avalonia.Input.PointerPressedEventArgs e)
    {
        if (e.GetCurrentPoint(null).Properties.IsLeftButtonPressed)
        {
            var window = this.GetVisualRoot() as Window;
            window?.BeginMoveDrag(e);
        }
    }

    private void ChangeViewButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        string tabButtonName;
        if(sender is Button TabButton)
        {
            switch(TabButton.Name)
            {
                case "HomeTab":
                    if (ContentArea.Content is HomeView) return;
                    ContentArea.Content = new HomeView(ref _service, ref theme);
                    return;
                case "TasksTab":
                    if (ContentArea.Content is TasksView) return;
                    ContentArea.Content = new TasksView(ref _service, ref theme);
                    return;
                case "SettingsTab":
                    if (ContentArea.Content is SettingsView) return;
                    ContentArea.Content = new SettingsView(ref _service, ref theme);
                    return;
            }
        }   
    }
}