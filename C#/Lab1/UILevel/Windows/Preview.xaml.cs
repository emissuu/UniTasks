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
using DataProcessing.Models.Entities;

namespace DataProcessing.Windows
{
    /// <summary>
    /// Interaction logic for Preview.xaml
    /// </summary>
    public partial class Preview : Window
    {
        public Preview()
        {
            InitializeComponent();
            if (CurrentSession.Data != null)
            {
                PreviewDataGrid.ItemsSource = CurrentSession.Data.Songs.Take(16);
                Maintext.Content = CurrentSession.Data.Name + ": " + CurrentSession.Data.Number_Entries + " entries";
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
