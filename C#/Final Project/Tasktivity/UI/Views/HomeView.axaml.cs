using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Services.Implementations;
using Services.Models;

namespace UI;

public partial class HomeView : UserControl
{
    private ServiceStorage _service;
    public ThemeColors ActiveTheme { get; set; }
    public HomeView(ref ServiceStorage serviceStorage, ref ThemeColors theme)
    {
        _service = serviceStorage;
        ActiveTheme = theme;
        InitializeComponent();
        DataContext = this;
    }
}