using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Data.Models;
using Services.Implementations;
using Services.Models;
using UI.Windows;

namespace UI.Views;

public partial class SettingsView : UserControl
{
    private ServiceStorage _service;
    public SettingsView(ref ServiceStorage serviceStorage)
    {
        _service = serviceStorage;
        InitializeComponent();
        DataContext = this;
        Update();
    }
    private void Update()
    {
        User user = _service._userServ.GetUser();
        TextBoxUserName.Text = user.UserName;
        foreach (ThemeColors theme in _service._themeServ.GetAllThemeColors())
            ComboBoxThemes.Items.Add(theme);
        {
            int themeId = _service._userServ.GetCurrentTheme().Id;
            foreach (object item in ComboBoxThemes.Items)
                if ((item as ThemeColors).Id == themeId)
                {
                    ComboBoxThemes.SelectedItem = item;
                    break;
                }
        }
    }

    private void ButtonSaveChanges_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        User user = _service._userServ.GetUser();
        user.UserName = TextBoxUserName.Text;
        user.ActiveThemeId = (ComboBoxThemes.SelectedItem as ThemeColors).Id;
        _service._userServ.Update(user);
        MainWindow.Instance.UpdateTheme();
    }

    private void ButtonResetStaticData_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        TextBoxUserName.Text = "Hi! I reset your ass!";
    }

    private void ButtonShowAdvanced_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ButtonResetStatic.IsVisible = true;
    }
}