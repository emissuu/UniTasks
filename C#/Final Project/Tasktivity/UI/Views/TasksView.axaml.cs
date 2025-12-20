using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Data.Models;
using Services.Implementations;
using Services.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UI.Windows;

namespace UI.Views;

public partial class TasksView : UserControl
{
    private ServiceStorage _service;
    public TasksView(ref ServiceStorage serviceStorage)
    {
        _service = serviceStorage;
        InitializeComponent();
        DataContext = this;
        UpdateComboBoxes();
        UpdateTasks();
    }

    private void UpdateTaskList()
    {
        List<TaskPriority> tasks = _service._taskServ.GetAllTaskPriorities().ToList();
        foreach (TaskPriority task in tasks)
        {
            ListBoxTasks.Items.Add(task);
        }
    }
    private void UpdateComboBoxes()
    {
        ComboBoxSortingProperty.SelectedIndex = 0;
        ComboBoxSortingOrder.SelectedIndex = 0;
        ComboBoxCategory.Items.Add(new Category() { Id = 0, Name = "All categories", Color = MainWindow.Instance.Theme.Background.ToString() });
        foreach (Category category in _service._categoryServ.GetAll())
            ComboBoxCategory.Items.Add(category);
        ComboBoxCategory.SelectedIndex = 0;
    }
    private void UpdateTasks()
    {
        if (!IsInitialized) return;
        List<TaskPriority> tasks = new(_service._taskServ.GetAllTaskPriorities()
            .Where(t => TextBoxSearch.Text == null || TextBoxSearch.Text == string.Empty || t.Name.Contains(TextBoxSearch.Text.Trim(), System.StringComparison.CurrentCultureIgnoreCase))
            .Where(t => ComboBoxCategory.SelectedIndex == 0 || ((Category)ComboBoxCategory.SelectedItem).Id == t.Category.Id)
            .ToList()
            );
        tasks = ComboBoxSortingOrder.SelectedIndex switch
        {
            0 => ComboBoxSortingProperty.SelectedIndex switch
            {
                0 => tasks.OrderBy(t => t.HoursLeft).ToList(),
                1 => tasks.OrderBy(t => t.Size.Experience).ThenBy(t => t.HoursLeft).ToList(),
                2 => tasks.OrderBy(t => t.Name).ToList(),
                3 => tasks.Where(t => t.IsCompleted).OrderBy(t => t.CompletedAt).ToList()
            },
            1 => ComboBoxSortingProperty.SelectedIndex switch
            {
                0 => tasks.OrderByDescending(t => t.HoursLeft).ToList(),
                1 => tasks.OrderByDescending(t => t.Size.Experience).ThenBy(t => t.HoursLeft).ToList(),
                2 => tasks.OrderByDescending(t => t.Name).ToList(),
                3 => tasks.Where(t => t.IsCompleted).OrderByDescending(t => t.CompletedAt).ToList()
            }
        };
        ListBoxTasks.Items.Clear();
        foreach (var task in tasks)
            ListBoxTasks.Items.Add(task);
    }

    private void ComboBox_UpdateTasksList(object? sender, SelectionChangedEventArgs e) => UpdateTasks();
    private void TextBox_UpdateTasksList(object? sender, TextChangedEventArgs e) => UpdateTasks();
}