using Microsoft.EntityFrameworkCore;
using Data.Models;
using Data.Extensions;

namespace Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<TaskSize> TaskSizes => Set<TaskSize>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Models.Task> Tasks => Set<Models.Task>();
        public DbSet<Theme> Themes => Set<Theme>();
        public DbSet<User> User => Set<User>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Tasktivity");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, "tasktivity.db");

            optionsBuilder.UseSqlite($"Data Source={path}");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DbInitializer.BasicInitialization(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
