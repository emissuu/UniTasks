using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Threading;
using Avalonia.VisualTree;
using Services.Implementations;
using Services.Models;
using System;
using UI.Views;

namespace UI.Windows;

public partial class MainWindow : Window
{
    internal static MainWindow Instance { get; private set; }
    private ServiceStorage _service;
    private ThemeColors _theme;
    private DispatcherTimer _timer;
    private string _currentDate;
    public MainWindow(ref ServiceStorage serviceStorage)
    {
        Instance = this;
        _service = serviceStorage;
        {
            _timer = new DispatcherTimer() { Interval = TimeSpan.FromMinutes(2) };
            _timer.Tick += (sender, e) => { UpdateDate(); };
            _timer.Start();
        }
        InitializeComponent();
        DataContext = this;
        ContentArea.Content = new HomeView(ref _service);
        UpdateDate();
        UpdateTheme();
    }
    public ThemeColors Theme { get => _theme; }
    private void UpdateDate() => CurrentDate = $"- {DateTime.Now:dddd, MMMM d, yyyy} -";
    public void UpdateTheme()
    {
        _theme = _service._userServ.GetCurrentTheme();
        Application.Current.Resources["ThemeAccent"] = _theme.Accent.Color;
        Application.Current.Resources["ThemeForeground"] = _theme.Foreground.Color;
        Application.Current.Resources["ThemeSubForeground"] = _theme.SubForeground.Color;
        Application.Current.Resources["ThemeSubSubForeground"] = _theme.SubSubForeground.Color;
        Application.Current.Resources["ThemeBackground"] = _theme.Background.Color;
        Application.Current.Resources["ThemeSubBackground"] = _theme.SubBackground.Color;
        Application.Current.Resources["ThemeSubSubBackground"] = _theme.SubSubBackground.Color;
    }
    public string CurrentDate
    {
        get => _currentDate;
        set
        {
            if (value != _currentDate)
                _currentDate = value;
            TitleBarDate.Text = CurrentDate;
        }
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
        if (sender is Button TabButton)
        {
            switch (TabButton.Name)
            {
                case "HomeTab":
                    if (ContentArea.Content is HomeView) return;
                    ContentArea.Content = new HomeView(ref _service);
                    HomeTab.Classes.Clear();
                    HomeTab.Classes.Add("SideBarChosen");
                    TasksTab.Classes.Clear();
                    TasksTab.Classes.Add("SideBar");
                    SettingsTab.Classes.Clear();
                    SettingsTab.Classes.Add("SideBar");
                    return;
                case "TasksTab":
                    if (ContentArea.Content is TasksView) return;
                    ContentArea.Content = new TasksView(ref _service);
                    TasksTab.Classes.Clear();
                    TasksTab.Classes.Add("SideBarChosen");
                    HomeTab.Classes.Clear();
                    HomeTab.Classes.Add("SideBar");
                    SettingsTab.Classes.Clear();
                    SettingsTab.Classes.Add("SideBar");
                    return;
                case "SettingsTab":
                    if (ContentArea.Content is SettingsView) return;
                    ContentArea.Content = new SettingsView(ref _service);
                    SettingsTab.Classes.Clear();
                    SettingsTab.Classes.Add("SideBarChosen");
                    HomeTab.Classes.Clear();
                    HomeTab.Classes.Add("SideBar");
                    TasksTab.Classes.Clear();
                    TasksTab.Classes.Add("SideBar");
                    return;
            }
        }
    }

    private void MinimizeButton_ActualThemeVariantChanged(object? sender, System.EventArgs e)
    {
    }
}