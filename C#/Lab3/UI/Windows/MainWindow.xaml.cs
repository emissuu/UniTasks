using System.Windows;
using Services.Storages;

namespace UI.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ServiceStorage _serviceStorage;
        public MainWindow(ref ServiceStorage serviceStorage)
        {
            _serviceStorage = serviceStorage;
            InitializeComponent();
        }
    }
}