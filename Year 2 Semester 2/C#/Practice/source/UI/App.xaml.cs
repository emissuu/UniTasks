using Data.Context;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using UI.Extensions;
using UI.Windows;

namespace UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void StartupInitialization(object sender, StartupEventArgs e)
        {
            var services = new ServiceCollection();

            services.AddDbContext<AppDbContext>();
            ServiceCollectionExtensions.AddRepositories(services);
            ServiceCollectionExtensions.AddServices(services);

            var mainWindow = new Main(services);
            mainWindow.Show();
        }
    }
}