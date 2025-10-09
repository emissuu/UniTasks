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
using DataProcessing.Data.Reports;

namespace DataProcessing.Windows
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
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show("File not found", "MusicStore", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error reading file", "MusicStore", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (CsvHelper.HeaderValidationException ex)
                {
                    MessageBox.Show("Header names are missing or spelled differently.", "MusicStore", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (CsvHelper.ReaderException ex)
                {
                    MessageBox.Show("Error reading CSV data. Please ensure the data is formatted correctly.", "MusicStore", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    MessageBox.Show("Error reading Excel data. Please ensure the file is not open in another program.", "MusicStore", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (System.Reflection.TargetInvocationException ex)
                {
                    MessageBox.Show("Error reading Excel data. Please ensure the file is not open in another program.", "MusicStore", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (System.InvalidCastException ex)
                {
                    MessageBox.Show("Error processing Excel data. Please ensure the data is formatted correctly.", "MusicStore", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (System.ArgumentException ex)
                {
                    MessageBox.Show("Cannot import invalid data", "MusicStore", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (System.Text.Json.JsonException ex)
                {
                    MessageBox.Show("Error processing JSON data. Please ensure the data is formatted correctly.", "MusicStore", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (System.Xml.XmlException ex)
                {
                    MessageBox.Show("Error processing XML data. Please ensure the data is formatted correctly.", "MusicStore", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred: " + ex.Message, "MusicStore", MessageBoxButton.OK, MessageBoxImage.Error);
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
                catch (IOException ex)
                {
                    MessageBox.Show("Error writing file", "MusicStore", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show("You do not have permission to save to this location.", "MusicStore", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred: " + ex.Message, "MusicStore", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CreateReport_Click(object sender, RoutedEventArgs e)
        {
            IReportable reportGenerator = new DocxReportService();
            SaveFileDialog saveFileDialog = new();
            if (sender is MenuItem menuItem)
            {
                if ((string)menuItem.Tag == "docx")
                {
                    saveFileDialog.Filter = "Word Document (*.docx)|*.docx|All Files|*.*";
                    saveFileDialog.Title = "Generate report";
                    reportGenerator = new DocxReportService();
                }
                else
                {
                    saveFileDialog.Filter = "MS Excel Files (*.xlsx)|*.xlsx|All Files|*.*";
                    saveFileDialog.Title = "Generate report";
                    reportGenerator = new XlsxReportService();
                }
            }
            bool? result = saveFileDialog.ShowDialog();
            if (result == true)
            {
                try
                {
                    if (CurrentSession.Data != null)
                    {
                        reportGenerator.GenerateReport(saveFileDialog.FileName, CurrentSession.Data);
                        MessageBox.Show("Report generated successfully.", "MusicStore", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("No data loaded. Cannot generate report.", "MusicStore", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error writing file", "MusicStore", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show("You do not have permission to save to this location.", "MusicStore", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    MessageBox.Show("Error generating report. Please ensure the file is not open in another program.", "MusicStore", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (System.Reflection.TargetInvocationException ex)
                {
                    MessageBox.Show("Error generating report. Please ensure the file is not open in another program.", "MusicStore", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (System.InvalidCastException ex)
                {
                    MessageBox.Show("Error processing data for report. Please ensure the data is formatted correctly.", "MusicStore", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred: " + ex.Message, "MusicStore", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void CreateChart_Click(object sender, RoutedEventArgs e)
        {
            ChartPreview chartPreview = new();
            if (CurrentSession.Data != null)
            {
                chartPreview.ShowDialog();
            }
            else
            {
                MessageBox.Show("No data loaded. Cannot create chart.", "MusicStore", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}