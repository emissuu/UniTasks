using System.Windows;
using Microsoft.EntityFrameworkCore;
using Data.Context;
using Services.Storages;

namespace UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private DbContext _context;
        private RepositoryStorage _repositoryStorage;
        private ServiceStorage _serviceStorage;

        public App()
        {
            _context = new AppDbContext();
            _repositoryStorage = new RepositoryStorage(_context);
            _serviceStorage = new ServiceStorage(_repositoryStorage);

            MainWindow = new MainWindow(_serviceStorage);
            MainWindow.Show();
        }
    }

}
