using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Services.Implementations;
using Services.Models;

namespace UI.Views;

public partial class SettingsView : UserControl
{
    private ServiceStorage _service;
    public ThemeColors ActiveTheme { get; set; }
    public SettingsView(ref ServiceStorage serviceStorage, ref ThemeColors theme)
    {
        _service = serviceStorage;
        ActiveTheme = theme;
        InitializeComponent();
        DataContext = this;
    }
}