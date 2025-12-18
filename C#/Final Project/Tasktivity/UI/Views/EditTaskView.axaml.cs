using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Services.Implementations;

namespace UI.Views;

public partial class EditTaskView : UserControl
{
    private ServiceStorage _service;
    private int _taskId;
    public EditTaskView(ref ServiceStorage service, int taskId)
    {
        _service = service;
        _taskId = taskId;
        InitializeComponent();
        DataContext = this;
    }
}