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
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            var services = new ServiceCollection();

            services.AddDbContext<AppDbContext>();
            ServiceCollectionExtensions.AddRepositories(services);
            ServiceCollectionExtensions.AddServices(services);

            var servicesProvider = services.BuildServiceProvider();

            var login = new Login(servicesProvider);
            login.ShowDialog();
            if (login.UserKey == null)
            {
                Application.Current.Shutdown();
                return;
            }
            var mainWindow = new Main(login.UserKey, servicesProvider);
            Application.Current.MainWindow = mainWindow;
            Application.Current.ShutdownMode = ShutdownMode.OnLastWindowClose;
            mainWindow.Show();

        }
    }
}