using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Services.Implementations;
using Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace UI.Views;

public partial class TasksView : UserControl
{
    private ServiceStorage _service;
    public TasksView(ref ServiceStorage serviceStorage)
    {
        _service = serviceStorage;
        InitializeComponent();
        DataContext = this;
        UpdateTaskList();
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
        
    }
}