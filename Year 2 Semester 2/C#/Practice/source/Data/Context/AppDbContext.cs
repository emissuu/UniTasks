using Data.Extensions;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Status> Statuses => Set<Status>();
        public DbSet<Team> Teams => Set<Team>();
        public DbSet<TeamUser> TeamUsers => Set<TeamUser>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Models.Task> Tasks => Set<Models.Task>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = File.ReadAllText("dbconnection.txt");
            optionsBuilder.UseMySQL(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.CreatedBy)
                .WithMany(t => t.CreatedTeams)
                .HasForeignKey(t => t.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TeamUser>()
                .HasKey(tu => new {tu.TeamId, tu.UserId});

            modelBuilder.Entity<TeamUser>()
                .HasOne(tu => tu.Team)
                .WithMany()
                .HasForeignKey(tu => tu.TeamId);

            modelBuilder.Entity<TeamUser>()
                .HasOne(tu => tu.User)
                .WithMany()
                .HasForeignKey(tu => tu.UserId);

            modelBuilder.Entity<Models.Task>()
                .HasOne(t => t.CreatedBy)
                .WithMany(t => t.CreatedTasks)
                .HasForeignKey(t => t.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Models.Task>()
                .HasOne(t => t.AssignedTo)
                .WithMany(t => t.AssignedTasks)
                .HasForeignKey(t => t.AssignedToId)
                .OnDelete(DeleteBehavior.Restrict);

            Initializer.Initialize(modelBuilder);
        }
    }
}
