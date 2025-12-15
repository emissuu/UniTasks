using System;
using System.Collections.Generic;
using System.Numerics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Services.Implementations;
using Services.Models;


namespace UI.Views;

public partial class HomeView : UserControl
{
    private ServiceStorage _service;
    public ThemeColors ActiveTheme { get; set; }
    public List<TaskPriority> Tasks { get; set; }
    public HomeView(ref ServiceStorage serviceStorage, ref ThemeColors theme)
    {
        _service = serviceStorage;
        ActiveTheme = theme;
        InitializeComponent();
        Tasks = new List<TaskPriority>();
        DataContext = this;
        Tasks.Add(new TaskPriority()
        {
            Id = 0,
            Name = "SuperTextTask Name",
            TaskSizeId = 0,
            TaskSizeName = "Big one (2 days min)",
            CategoryId = 0,
            CategoryName = "Category name thing",
            CategoryColor = new Avalonia.Media.SolidColorBrush(new Avalonia.Media.Color(100, 146, 32, 245)),
            WhenTo = new DateTimeOffset(2025, 12, 18, 12, 0, 0, TimeSpan.Zero)
        });
        UpdateListBoxDeadlines();
    }
    private void UpdateListBoxDeadlines()
    {
        ListBoxDeadlinesSoon.Items.Clear();
        foreach (var task in Tasks)
        {
            ListBoxDeadlinesSoon.Items.Add(task);
        }
    }
}