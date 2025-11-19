using Microsoft.EntityFrameworkCore;
using Main.Models;
using Main.Extensions;

namespace Main.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Administrator> Administrators => Set<Administrator>();
        public DbSet<Event> Events => Set<Event>();
        public DbSet<Team> Teams => Set<Team>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<TeamMember> TeamMembers => Set<TeamMember>();
        public DbSet<Partner> Partners => Set<Partner>();
        public DbSet<Zone> Zones => Set<Zone>();
        public DbSet<ZoneActivation> ZoneActivations => Set<ZoneActivation>();
        public DbSet<EventBlock> EventBlocks => Set<EventBlock>();
        public DbSet<Worker> Workers => Set<Worker>();
        public DbSet<WorkerShift> WorkerShifts => Set<WorkerShift>();
        public DbSet<Incident> Incidents => Set<Incident>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=EventOrganizerDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;Command Timeout=0");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DbInitializer.SeedTHEData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
