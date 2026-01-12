using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataProcessing.Models.Entities;
using DocumentFormat.OpenXml.Bibliography;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Wpf;
using Microsoft.Win32;
using DataProcessingRestored.ChartHandling;


namespace DataProcessing.Windows
{
    /// <summary>
    /// Interaction logic for ChartPreview.xaml
    /// </summary>
    public partial class ChartPreview : Window
    {
        PlotModel plotModel;
        public ChartPreview()
        {
            InitializeComponent();
        }

        private void RegenerateGraph()
        {
            plotModel = ChartHandler.GenerateChart(
                (ChartHandler.ChartType)ChartTypeComboBox.SelectedIndex,
                ChartTitleTextBox.Text);
            PlotView.Model = plotModel;
        }

        // Events

        private void RefreshPlotButton_Click(object sender, RoutedEventArgs e)
        {
            RegenerateGraph();
        }

        private void ExportPNGButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new();
            dialog.Filter = "PNG Image|*.png|All Files|*.*";
            if (dialog.ShowDialog() == true)
            {
                ChartHandler.GeneratePngChart(
                    (ChartHandler.ChartType)ChartTypeComboBox.SelectedIndex,
                    ChartTitleTextBox.Text,
                    dialog.FileName);
            }
        }
    }
}
