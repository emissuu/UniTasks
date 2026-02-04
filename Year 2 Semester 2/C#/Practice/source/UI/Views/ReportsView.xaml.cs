using Data.Models;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using Services.Interfaces;
using Services.Models;
using Services.ReportHandlers;
using System.IO;
using System.Windows.Controls;

namespace UI.Views
{
    /// <summary>
    /// Interaction logic for ReportsView.xaml
    /// </summary>
    public partial class ReportsView : UserControl
    {
        private IServiceProvider _services;
        private User _activeUser;
        private List<AuditLogDetails> _auditLogs;
        public ReportsView(User user, IServiceProvider services)
        {
            _activeUser = user;
            _services = services;
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            ComboBoxEntry.Items.Add("All");
            ComboBoxEntry.SelectedIndex = 0;
            
            Update();
        }

        public void Update()
        {
            _auditLogs = _services.GetService<IAuditLogService>().GetAllAuditDetails().ToList();
            {
                // Filters
                if (ComboBoxType.SelectedIndex == 0)
                {

                }
                else if (ComboBoxType.SelectedIndex == 1)
                {
                    _auditLogs = _auditLogs
                        .Where(a => a.EntityType == "User")
                        .ToList();
                    if (ComboBoxEntry.SelectedIndex != 0)
                    {
                        var user = ComboBoxEntry.SelectedItem as UserDetails;
                        _auditLogs = _auditLogs
                            .Where(a => a.User.Id == user.Id)
                            .ToList();
                    }
                }
                else if (ComboBoxType.SelectedIndex == 2)
                {
                    _auditLogs = _auditLogs
                        .Where(a => a.EntityType == "Project" || a.EntityType == "Task")
                        .ToList();
                    if (ComboBoxEntry.SelectedIndex != 0)
                    {
                        var project = ComboBoxEntry.SelectedItem as Project;
                        _auditLogs = _auditLogs
                            .Where(a =>
                            a.EntityType == "Project" && a.EntityId == project.Id ||
                            a.EntityType == "Task" && project.Tasks.Any(p => a.EntityId == p.Id))
                            .ToList();
                    }
                }
            }
            {
                // Sorting
                if (ComboBoxSortBy.SelectedIndex == 0)
                {
                    // Date
                    if (ComboBoxOrder.SelectedIndex == 0)
                        _auditLogs = _auditLogs
                            .OrderBy(a => a.CreatedAt)
                            .ToList();
                    else
                        _auditLogs = _auditLogs
                            .OrderByDescending(a => a.CreatedAt)
                            .ToList();
                }
                else if (ComboBoxSortBy.SelectedIndex == 1)
                {
                    // Entity Id
                    if (ComboBoxOrder.SelectedIndex == 0)
                        _auditLogs = _auditLogs
                            .OrderBy(a => a.EntityId)
                            .ThenBy(a => a.CreatedAt)
                            .ToList();
                    else
                        _auditLogs = _auditLogs
                            .OrderByDescending(a => a.EntityId)
                            .ThenByDescending(a => a.CreatedAt)
                            .ToList();
                }
                else if (ComboBoxSortBy.SelectedIndex == 2)
                {
                    // User
                    if (ComboBoxOrder.SelectedIndex == 0)
                        _auditLogs = _auditLogs
                            .OrderBy(a => a.User.Id)
                            .ThenBy(a => a.CreatedAt)
                            .ToList();
                    else
                        _auditLogs = _auditLogs
                            .OrderByDescending(a => a.User.Id)
                            .ThenByDescending(a => a.CreatedAt)
                            .ToList();
                }
                else if (ComboBoxSortBy.SelectedIndex == 3)
                {
                    // Action
                    if (ComboBoxOrder.SelectedIndex == 0)
                        _auditLogs = _auditLogs
                            .OrderBy(a => a.Action)
                            .ThenBy(a => a.CreatedAt)
                            .ToList();
                    else
                        _auditLogs = _auditLogs
                            .OrderByDescending(a => a.Action)
                            .ThenByDescending(a => a.CreatedAt)
                            .ToList();
                }
            }
            ItemsControlLogs.Items.Clear();
            foreach (var auditLog in _auditLogs)
            {
                ItemsControlLogs.Items.Add(auditLog);
            }
        }

        private void ButtonCreateReport_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = Environment. GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialog.Title = "TeamTask Report";
            dialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                FileInfo fileInfo = new FileInfo(dialog.FileName);
                ExcelReportHandler.CreateReport(_auditLogs, _activeUser, fileInfo.FullName);
            }
        }

        private void ButtonApplyFilters_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Update();
        }

        private void ComboBoxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!this.IsInitialized) return;
            ComboBoxEntry.Items.Clear();
            ComboBoxEntry.Items.Add("All");
            ComboBoxEntry.SelectedIndex = 0;
            if (ComboBoxType.SelectedIndex == 0)
            {
                
            }
            else if (ComboBoxType.SelectedIndex == 1)
            {
                var users = _services.GetService<IUserService>().GetAllUserDetails()
                    .OrderBy(u => u.UserName)
                    .ToList();
                foreach (var user in users)
                {
                    ComboBoxEntry.Items.Add(user);
                }
            }
            else if (ComboBoxType.SelectedIndex == 2)
            {
                var projects = _services.GetService<IProjectService>().GetAll()
                    .OrderBy(u => u.Name)
                    .ToList();
                foreach (var project in projects)
                {
                    ComboBoxEntry.Items.Add(project);
                }
            }
        }
    }
}
