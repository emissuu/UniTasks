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
                3 => tasks.OrderBy(t => t.CompletedAt).ToList()
            },
            1 => ComboBoxSortingProperty.SelectedIndex switch
            {
                0 => tasks.OrderByDescending(t => t.HoursLeft).ToList(),
                1 => tasks.OrderByDescending(t => t.Size.Experience).ThenBy(t => t.HoursLeft).ToList(),
                2 => tasks.OrderByDescending(t => t.Name).ToList(),
                3 => tasks.OrderByDescending(t => t.CompletedAt).ToList()
            }
        };
        ListBoxTasks.Items.Clear();
        foreach (var task in tasks)
            ListBoxTasks.Items.Add(task);
    }

    private void ComboBox_UpdateTasksList(object? sender, SelectionChangedEventArgs e) => UpdateTasks();
    private void TextBox_UpdateTasksList(object? sender, TextChangedEventArgs e) => UpdateTasks();
    private void CheckBoxComplete_IsCheckedChanged(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (ListBoxTasks.Items.Count == 0) return;
        TaskPriority task = (sender as CheckBox)?.DataContext as TaskPriority;
        task.IsCompleted = (bool)(sender as CheckBox)?.IsChecked;
        Task origTask = _service._taskServ.GetById(task.Id);
        origTask.CompletedAt = task.CompletedAt;
        if (!origTask.IsExpAcquired)
        {
            _service._userServ.AddExp(task.Size.Experience);
            origTask.IsExpAcquired = true;
        }
        _service._taskServ.Update(origTask);
        UpdateTasks();
    }

    private void TextBox_LostFocus(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        TaskPriority task = (sender as TextBox)?.DataContext as TaskPriority;
        if (_service._taskServ.GetById(task.Id).Notes != task.Notes)
        {
            SaveTextBoxText(task);
            UpdateTasks();
        }
    }

    private void TextBox_KeyDown(object? sender, Avalonia.Input.KeyEventArgs e)
    {
        if (e.Key == Avalonia.Input.Key.Escape)
        {
            SaveTextBoxText((sender as TextBox)?.DataContext as TaskPriority);
            UpdateTasks();
        }
    }
    private void SaveTextBoxText(TaskPriority task)
    {
        Task origTask = _service._taskServ.GetById(task.Id);
        origTask.Notes = task.Notes;
        if (!origTask.IsExpAcquired)
        {
            _service._userServ.AddExp(origTask.Size.Experience);
            origTask.IsExpAcquired = true;
        }
        _service._taskServ.Update(origTask);
    }

    private void ButtonEditTask_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        EditPopup.Child = new EditTaskView(ref _service, ref EditPopup, (sender as Button).DataContext as TaskPriority);
        EditPopup.IsOpen = true;
    }
    private void ButtonNewTask_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        EditPopup.Child = new EditTaskView(ref _service, ref EditPopup, null);
        EditPopup.IsOpen = true;
    }

    private void EditPopup_Closed(object? sender, System.EventArgs e)
    {
        UpdateTasks();
    }
}