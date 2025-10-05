using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataProcessing.Data.Interfaces;
using DataProcessing.Models.Entities;
using DataProcessing.Data.Providers;
using Microsoft.Win32;

namespace DataProcessing.UI.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Update();
        }

        private void Update()
        {
            if (CurrentSession.Data != null)
            {
                StatusBarText.Content = $"Data loaded: {CurrentSession.Data.Number_Entries} entries";
                StatusBarPath.Content = CurrentSession.Data.DataPath;
                MainDataGrid.ItemsSource = CurrentSession.Data.Songs;
                MainDataGrid.Items.Refresh();
            }
            else
            {
                StatusBarText.Content = "No data loaded";
                StatusBarPath.Content = "No data loaded";
                MainDataGrid.Items.Refresh();
            }
        }

        // ---------- Clicks ----------

        private void OpenDataset_Click(object sender, RoutedEventArgs e)
        {
            IReadable dataReader;
            OpenFileDialog openFileDialog = new()
            {
                Filter = "JSON Files (*.json)|*.json|CSV Files (*.csv)|*.csv|MS Excel Files (*.xlsx)|*.xlsx|XML Files (*.xml)|*.xml|All Files|*.*",
                Title = "Open dataset"
            };
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                    switch (fileInfo.Extension.ToLower().TrimStart('.'))
                    {
                        case "json":
                            dataReader = new JsonProvider();
                            break;
                        case "csv":
                            dataReader = new CsvProvider();
                            break;
                        case "xlsx":
                            dataReader = new XlsxProvider();
                            break;
                        case "xml":
                            dataReader = new XmlProvider();
                            break;
                        default:
                            MessageBox.Show("Extension not recognized. Session terminated", "MusicStore", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                    }
                    if (CurrentSession.Data != null)
                    {
                        MessageBoxResult messageResult = MessageBox.Show("Data already loaded. Do you want to overwrite current data?", "MusicStore", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                        if (messageResult == MessageBoxResult.Cancel)
                        {
                            return;
                        }
                        else
                        {
                            CurrentSession.Data = null;
                        }
                    }
                    CurrentSession.Data = dataReader.ReadData(openFileDialog.FileName);
                    Preview previewWindow = new();
                    bool? previewResult = previewWindow.ShowDialog();
                    if (previewResult == false)
                    {
                        CurrentSession.Data = null;
                    }
                    Update();
                }
                catch (Exception ex)
                {
                    // Do the actual error handling here
                }
            }
        }

        private void SaveDataset_Click(object sender, RoutedEventArgs e)
        {
            IWriteable dataWriter;
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "JSON Files (*.json)|*.json|CSV Files (*.csv)|*.csv|MS Excel Files (*.xlsx)|*.xlsx|XML Files (*.xml)|*.xml|All Files|*.*",
                Title = "Save dataset"
            };
            bool? result = saveFileDialog.ShowDialog();
            if (result == true)
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
                    switch (fileInfo.Extension.ToLower().TrimStart('.'))
                    {
                        case "json":
                            dataWriter = new JsonProvider();
                            break;
                        case "csv":
                            dataWriter = new CsvProvider();
                            break;
                        case "xlsx":
                            dataWriter = new XlsxProvider();
                            break;
                        case "xml":
                            dataWriter = new XmlProvider();
                            break;
                        default:
                            MessageBox.Show("Extension not recognized. Session terminated", "MusicStore", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                    }
                    if (CurrentSession.Data != null)
                    {
                        dataWriter.WriteData(saveFileDialog.FileName, CurrentSession.Data);
                    }
                    else
                    {
                        MessageBox.Show("No data loaded. Nothing to save.", "MusicStore", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Do the actual error handling here
                }
            }
        }
    }
}