using Microsoft.EntityFrameworkCore;
using Main.Models;

namespace Main.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Participant> Participants => Set<Participant>();
        public DbSet<TeamMember> TeamMembers => Set<TeamMember>();
        public DbSet<Accreditation> Accreditations => Set<Accreditation>();
        public DbSet<Stage> Stages => Set<Stage>();
        public DbSet<Performance> Performances => Set<Performance>();
        public DbSet<TechnicalBreak> TechnicalBreaks => Set<TechnicalBreak>();
        public DbSet<Volunteer> Volunteers => Set<Volunteer>();
        public DbSet<Zone> Zones => Set<Zone>();
        public DbSet<VolunteerShift> VolunteersShifts => Set<VolunteerShift>();
        public DbSet<Partner> Partners => Set<Partner>();
        public DbSet<ActivationZone> ActivationZones => Set<ActivationZone>();
        public DbSet<LogisticItem> LogisticItems => Set<LogisticItem>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Incident> Incidents => Set<Incident>();
        public DbSet<DailyReport> DailyReports => Set<DailyReport>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=EventOrganizerDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;Command Timeout=0");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
