using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Services.Storages;
using UI2.Windows;
using SkiaSharp;

namespace UI2
{
    public partial class App : Application
    {
        private DbContext _context;
        private RepositoryStorage _repositoryStorage;
        private ServiceStorage _serviceStorage;

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
            _context = new AppDbContext();
            _repositoryStorage = new RepositoryStorage(_context);
            _serviceStorage = new ServiceStorage(_repositoryStorage);
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