using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Data.Models;
using Services.Storages;

namespace UI2.Views;

public partial class WorkerShiftsView : UserControl
{
    private ServiceStorage _serviceStorage;
    private int _eventId;
    public ObservableCollection<WorkerShift> WorkerShifts { get; set; }
    private WorkerShift? _selectedWorkerShift;
    public WorkerShiftsView(ref ServiceStorage serviceStorage, int eventId)
    {
        _serviceStorage = serviceStorage;
        _eventId = eventId;
        InitializeComponent();
        WorkerShifts = new ObservableCollection<WorkerShift>(_serviceStorage._workerShiftServ.GetByEventId(_eventId));
        DataContext = this;
        foreach(var worker in _serviceStorage._workerServ.GetAllWorkerNames())
            ComboBoxWorker.Items.Add(worker);
        foreach(var eventBlock in _serviceStorage._eventBlockServ.GetAllEventBlockNamesByEventId(_eventId))
            ComboBoxEventBlock.Items.Add(eventBlock);
        ComboBoxWorker.SelectedIndex = 0;
        ComboBoxEventBlock.SelectedIndex = 0;
    }
    public WorkerShift? SelectedWorkerShift
    {
        get => _selectedWorkerShift;
        set => _selectedWorkerShift = value;
    }
    public void UpdateGrid()
    {
        WorkerShifts.Clear();
        foreach (var ws in _serviceStorage._workerShiftServ.GetByEventId(_eventId))
            WorkerShifts.Add(ws);
    }
    public void ClearButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        SelectedWorkerShift = null;
        ComboBoxWorker.SelectedIndex = 0;
        ComboBoxEventBlock.SelectedIndex = 0;
    }
    public void SaveButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (SelectedWorkerShift != null)
        {
            int workerId = _serviceStorage._workerServ.GetIdByName((string)ComboBoxWorker.SelectedItem!);
            int eventBlockId = _serviceStorage._eventBlockServ.GetIdByNameAndEventId((string)ComboBoxEventBlock.SelectedItem!, _eventId);
            DateTime eventDate = _serviceStorage._eventServ.GetById(_eventId).Date.Value;
            _serviceStorage._workerShiftServ.Update(new WorkerShift()
            {
                Id = SelectedWorkerShift.Id,
                WorkerId = workerId,
                EventBlockId = eventBlockId,
                StartsAt = eventDate + _serviceStorage._eventBlockServ.GetById(eventBlockId)?.StartsAt?.TimeOfDay ?? null,
                EndsAt = eventDate + _serviceStorage._eventBlockServ.GetById(eventBlockId)?.EndsAt?.TimeOfDay ?? null
            });
            UpdateGrid();
        }
    }
    public void AddButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        int workerId = _serviceStorage._workerServ.GetIdByName((string)ComboBoxWorker.SelectedItem!);
        int eventBlockId = _serviceStorage._eventBlockServ.GetIdByNameAndEventId((string)ComboBoxEventBlock.SelectedItem!, _eventId);
        DateTime eventDate = _serviceStorage._eventServ.GetById(_eventId).Date.Value;
        _serviceStorage._workerShiftServ.Add(new WorkerShift()
        {
            WorkerId = workerId,
            EventBlockId = eventBlockId,
            StartsAt = eventDate + _serviceStorage._eventBlockServ.GetById(eventBlockId)?.StartsAt?.TimeOfDay ?? null,
            EndsAt = eventDate + _serviceStorage._eventBlockServ.GetById(eventBlockId)?.EndsAt?.TimeOfDay ?? null
        });
        UpdateGrid();
    }
    public void RemoveButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (SelectedWorkerShift != null)
        {
            _serviceStorage._workerShiftServ.Delete(SelectedWorkerShift.Id);
            UpdateGrid();
        }
    }
    private void DataGrid_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        ComboBoxWorker.SelectedItem = _selectedWorkerShift?.Worker?.Person?.Name ?? _serviceStorage._workerServ.GetAllWorkerNames().ToList()[0];
        ComboBoxEventBlock.SelectedItem = _selectedWorkerShift?.EventBlock?.Name ?? _serviceStorage._eventBlockServ.GetAllEventBlockNamesByEventId(_eventId).ToList()[0];
    }
}