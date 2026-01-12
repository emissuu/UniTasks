using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Data.Models;
using Services.Implementations;
using Services.Models;

namespace UI.Views;

public partial class HomeView : UserControl
{
    private ServiceStorage _service;
    public List<TaskPriority> Tasks { get; set; }
    public HomeView(ref ServiceStorage serviceStorage)
    {
        _service = serviceStorage;
        InitializeComponent();
        Tasks = new List<TaskPriority>();
        DataContext = this;
        Update();
    }
    private void Update()
    {
        UpdateWelcomeMessage();
        UpdateLvl();
        UpdateStats();
        UpdateTaskList();
    }
    private void UpdateWelcomeMessage()
    {
        byte hour = (byte)DateTime.Now.Hour;
        string? userName = _service._userServ.GetUser().UserName;
        if (userName == null) userName = "!";
        else userName = ", " + userName.Trim() + '!';
        string[] dateMessages = [
            "Good morning",
            "Good afternoon",
            "Good evening",
            "Good night"
            ];
        if (hour > 5 && hour <= 12) WelcomeTextBlock.Text = dateMessages[0] + userName;
        else if (hour > 12 && hour <= 18) WelcomeTextBlock.Text = dateMessages[1] + userName;
        else if (hour > 18 && hour <= 22) WelcomeTextBlock.Text = dateMessages[2] + userName;
        else WelcomeTextBlock.Text = dateMessages[3] + userName;
    }
    private void UpdateLvl()
    {
        int[] expies = _service._userServ.GetExperience();
        TextBlockLvl.Text = "Lvl " + expies[0];
        TextBlockExp.Text = $"{expies[1]} / {expies[2]}";
        ProgressBarExp.Value = 100 * expies[1] / expies[2];
    }
    private void UpdateStats()
    {
        IEnumerable<Task> tasks = _service._taskServ.GetAllSizes().Where(t => t.CompletedAt != null);
        TextBlockStatsTasksWeek.Text = $" - Tasks completed: {tasks.Where(t => ((TimeSpan)(DateTime.Now - t.CompletedAt)).TotalDays < 8 && ((TimeSpan)(DateTime.Now - t.CompletedAt)).TotalMinutes >= 0).Count()}";
        TextBlockStatsExpWeek.Text = $" - Experience got: {tasks.Where(t => ((TimeSpan)(DateTime.Now - t.CompletedAt)).TotalDays < 8 && ((TimeSpan)(DateTime.Now - t.CompletedAt)).TotalMinutes >= 0).Sum(t => t.Size.Experience)}";
        TextBlockStatsTasksTotal.Text = $" - Tasks completed: {tasks.Count()}";
        TextBlockStatsExpTotal.Text = $" - Experience got: {_service._userServ.GetUser().TotalExperience}";
    }
    private void UpdateTaskList()
    {
        List<TaskPriority> tasks = _service._taskServ.GetAllTaskPriorities().Where(t => t.CompletedAt == null && (
            t.Size.Id == 1 && (t.WhenTo - DateTime.Now).TotalDays <= 3 ||
            t.Size.Id == 2 && (t.WhenTo - DateTime.Now).TotalDays <= 5 ||
            t.Size.Id == 3 && (t.WhenTo - DateTime.Now).TotalDays <= 7 ||
            t.Size.Id == 4 && (t.WhenTo - DateTime.Now).TotalDays <= 11
            )).OrderByDescending(t => t.WhenTo).ToList();
        ListBoxDeadlinesSoon.Items.Clear();
        foreach (TaskPriority task in tasks)
        {
            ListBoxDeadlinesSoon.Items.Add(task);
        }
    }

    private void CheckBoxComplete_IsCheckedChanged(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (ListBoxDeadlinesSoon.Items.Count == 0) return;
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
        Update();
    }

    private void ButtonNewTask_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        EditPopup.Child = new EditTaskView(ref _service, ref EditPopup, null);
        EditPopup.IsOpen = true;
    }

    private void EditPopup_Closed(object? sender, EventArgs e)
    {
        UpdateTaskList();
    }
}