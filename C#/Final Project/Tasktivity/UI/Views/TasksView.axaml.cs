using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Services.Implementations;
using Services.Models;

namespace UI;

public partial class TasksView : UserControl
{
    private ServiceStorage _service;
    public ThemeColors ActiveTheme { get; set; }
    public TasksView(ref ServiceStorage serviceStorage, ref ThemeColors theme)
    {
        _service = serviceStorage;
        ActiveTheme = theme;
        InitializeComponent();
        DataContext = this;
    }
}