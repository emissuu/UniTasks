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
using FileCompressor.Data;
using Microsoft.Win32;
using SharpCompress.Compressors.Deflate;

namespace FileCompressor.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string pathFrom = "C:\\";
        string pathTo = "C:\\";
        ArchiveManage archivator;
        CompressionLevel compressionLevel;

        public MainWindow()
        {
            InitializeComponent();
            archivator = new ManageZip();
        }



        // ========== Events ==========

        private void LevelSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LevelSelector.SelectedIndex == 0)
                compressionLevel = CompressionLevel.None;
            else if (LevelSelector.SelectedIndex == 1)
                compressionLevel = CompressionLevel.Level1;
            else if (LevelSelector.SelectedIndex == 2)
                compressionLevel = CompressionLevel.Level3;
            else if (LevelSelector.SelectedIndex == 3)
                compressionLevel = CompressionLevel.Level5;
            else if (LevelSelector.SelectedIndex == 4)
                compressionLevel = CompressionLevel.Level7;
            else if (LevelSelector.SelectedIndex == 5)
                compressionLevel = CompressionLevel.Level9;
            else
                throw new Exception("Selection was not found.");
        }

        private void FormatSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FormatSelector.SelectedIndex == 0)
            {
                archivator = new ManageZip();
                LevelSelector.Visibility = Visibility.Visible;
            }
            else if (FormatSelector.SelectedIndex == 1)
            {
                archivator = new ManageTar();
                LevelSelector.Visibility = Visibility.Hidden;
            }
            else
                throw new Exception("Selection was not found.");
        }

        private void PathButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string tag = (string)button.Tag;
                OpenFileDialog dialog = new();
                dialog.ValidateNames = false;
                dialog.CheckFileExists = false;
                dialog.CheckPathExists = true;
                dialog.FileName = "FileSelection";
                bool? result = dialog.ShowDialog();
                if (result == true)
                {
                    if (tag == "0")
                    {
                        pathFrom = dialog.FileName.Length > 15 && dialog.FileName.Substring(dialog.FileName.Length - 13) == "FileSelection" ?
                            dialog.FileName.Remove(dialog.FileName.Length - 14) : dialog.FileName;
                        TextBoxFrom.Text = pathFrom;
                    }
                    else
                    {
                        pathTo = dialog.FileName.Length > 15 && dialog.FileName.Substring(dialog.FileName.Length - 13) == "FileSelection" ?
                            dialog.FileName.Remove(dialog.FileName.Length - 14) : dialog.FileName;
                        TextBoxTo.Text = pathTo;
                    }
                }
            }
        }

        private void AddToArchiveButton_Click(object sender, RoutedEventArgs e)
        {
            archivator.Archive(pathFrom, pathTo, compressionLevel);
        }

        private void ExtractArchiveButton_Click(object sender, RoutedEventArgs e)
        {
            archivator.Extract(pathFrom, pathTo);
        }
    }
}