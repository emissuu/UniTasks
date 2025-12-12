using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;
using Services.Implementations;

namespace UI
{
    public partial class App : Application
    {
        private DbContext _context;
        private RepositoryStorage _repostoryStorage;
        private ServiceStorage _serviceStorage;
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
            _context = new AppDbContext();
            _context.Database.EnsureCreated();
            _repostoryStorage = new RepositoryStorage(_context);
            _serviceStorage = new ServiceStorage(_repostoryStorage);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow(ref _serviceStorage);
            }
            base.OnFrameworkInitializationCompleted();
        }
    }
}