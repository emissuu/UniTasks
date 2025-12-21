using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using Data.Models;
using Services.Implementations;
using Services.Models;
using System;
using System.Reflection.Metadata.Ecma335;

namespace UI.Views;

public partial class EditTaskView : UserControl
{
    private ServiceStorage _service;
    private Popup _parent;
    public TaskPriority? Task;
    private bool _isEditing;
    public EditTaskView(ref ServiceStorage service, ref Popup parent, TaskPriority? task)
    {
        _service = service;
        Task = task;
        _parent = parent;
        _isEditing = task != null;
        InitializeComponent();
        DataContext = this;
        UpdateControls();
    }
    public void UpdateControls()
    {
        if (_isEditing)
        {
            TextBoxName.Text = Task.Name;
            ButtonSave.Content = "Save";
            ButtonRemove.IsVisible = true;
            foreach (TaskSize size in _service._taskSizeServ.GetAll())
                ComboBoxSize.Items.Add(size);
            foreach (object item in ComboBoxSize.Items)
                if ((item as TaskSize).Id == Task.Size.Id)
                {
                    ComboBoxSize.SelectedItem = item;
                    break;
                }
            foreach (Category category in _service._categoryServ.GetAll())
                ComboBoxCategory.Items.Add(category);
            foreach (object item in ComboBoxCategory.Items)
                if ((item as Category).Id == Task.Category.Id)
                {
                    ComboBoxCategory.SelectedItem = item;
                    break;
                }
            TimePickerWhenTo.SelectedTime = Task.WhenTo.TimeOfDay;
            DatePickerWhenTo.SelectedDate = Task.WhenTo.Date;
            TextBoxNotes.Text = Task.Notes;
        }
        else
        {
            ButtonSave.Content = "Create";
            ButtonRemove.IsVisible = false;
            foreach (TaskSize size in _service._taskSizeServ.GetAll())
                ComboBoxSize.Items.Add(size);
            ComboBoxSize.SelectedIndex = 0;
            foreach (Category category in _service._categoryServ.GetAll())
                ComboBoxCategory.Items.Add(category);
            ComboBoxCategory.SelectedIndex = 0;
            TimePickerWhenTo.SelectedTime = DateTime.Now.TimeOfDay;
            DatePickerWhenTo.SelectedDate = DateTime.Now.Date;
        }
    }

    private void ButtonClose_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ClosePopup();
    }

    private void ClosePopup()
    {
        _parent.Child = null;
        _parent.IsOpen = false;
    }

    private void ButtonRemove_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (!_isEditing) return;
        _service._taskServ.Delete(Task.Id);
        ClosePopup();
    }

    private void ButtonSave_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (TextBoxName.Text == string.Empty || TextBoxName.Text.Length < 3) return;
        if (!_isEditing)
        {
            _service._taskServ.Add(new Task()
            {
                Name = TextBoxName.Text,
                Notes = TextBoxNotes.Text,
                WhenTo = ((DateTimeOffset)DatePickerWhenTo.SelectedDate + (TimeSpan)TimePickerWhenTo.SelectedTime).UtcDateTime,
                CreatedAt = DateTimeOffset.UtcNow,
                CompletedAt = null,
                IsExpAcquired = false,
                SizeId = (ComboBoxSize.SelectedItem as TaskSize).Id,
                CategoryId = (ComboBoxCategory.SelectedItem as Category).Id,
            });
            ClosePopup();
        }
        else
        {
            Task task = _service._taskServ.GetById(Task.Id);
            task.Name = TextBoxName.Text;
            task.Notes = TextBoxNotes.Text;
            task.WhenTo = ((DateTimeOffset)DatePickerWhenTo.SelectedDate + (TimeSpan)TimePickerWhenTo.SelectedTime).UtcDateTime;
            task.SizeId = (ComboBoxSize.SelectedItem as TaskSize).Id;
            task.CategoryId = (ComboBoxCategory.SelectedItem as Category).Id;
            _service._taskServ.Update(task);
            ClosePopup();
        }
    }
}