using Microsoft.EntityFrameworkCore;
using Data.Models;

namespace Data.Context
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
        public DbSet<Person> Persons => Set<Person>();
        //public DbSet<TeamMemberEventBlock> TeamMemberEventBlocks => Set<TeamMemberEventBlock>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=EventOrganizerDBv2;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;Command Timeout=0");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<TeamMemberEventBlock>()
            //    .HasKey(te => new { te.TeamMemberId, te.EventBlockId });

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Person)        
                .WithMany(p => p.Tickets)
                .HasForeignKey(t => t.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TeamMember>()
                .HasOne(tm => tm.Person)
                .WithOne(tm => tm.TeamMember) 
                .HasForeignKey<TeamMember>(tm => tm.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkerShift>()
                .HasOne(ws => ws.Worker)
                .WithMany(w => w.WorkerShifts)
                .HasForeignKey(ws => ws.WorkerId)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<TeamMemberEventBlock>()
            //    .HasOne(te => te.TeamMember)
            //    .WithMany(tm => tm.TeamMemberEventBlocks)
            //    .HasForeignKey(te => te.TeamMemberId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<TeamMemberEventBlock>()
            //    .HasOne(te => te.EventBlock)
            //    .WithMany(eb => eb.TeamMemberEventBlocks)
            //    .HasForeignKey(te => te.EventBlockId)
            //    .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
