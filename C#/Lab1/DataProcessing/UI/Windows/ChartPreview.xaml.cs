using System;
using System.Collections.Generic;
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

namespace DataProcessing.UI.Windows
{
    /// <summary>
    /// Interaction logic for ChartPreview.xaml
    /// </summary>
    public partial class ChartPreview : Window
    {
        public ChartPreview()
        {
            InitializeComponent();
        }

        private void RegenerateGraph()
        {
            if (ChartTypeComboBox.SelectedIndex == 0)
                GenerateLinearGraph();
            else if (ChartTypeComboBox.SelectedIndex == 1)
                GenerateBarGraph();
            else if (ChartTypeComboBox.SelectedIndex == 2)
                GeneratePieGraph();
            else
                MessageBox.Show("Chart type does not exist.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void GenerateLinearGraph()
        {
            throw new NotImplementedException();
        }
        private void GenerateBarGraph()
        {
            throw new NotImplementedException();
        }
        private void GeneratePieGraph()
        {
            throw new NotImplementedException();
        }

        // Events

        private void ChartTitleTextBox_TextChanged(object sender, SelectionChangedEventArgs e)
        {
            RegenerateGraph();
        }
        private void ChartTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RegenerateGraph();
        }
        private void VariableComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RegenerateGraph();
        }
    }
}
