using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace UI.Windows
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        private IServiceCollection _services;
        public Main(IServiceCollection services)
        {
            _services = services;
            InitializeComponent();
        }
    }
}
