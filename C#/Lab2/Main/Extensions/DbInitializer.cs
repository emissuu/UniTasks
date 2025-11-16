using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Models;
using Microsoft.EntityFrameworkCore;

namespace Main.Extensions
{
    public static class DbInitializer
    {
        public static void SeedTHEData(this ModelBuilder modelBuilder)
        {
            // ===== Participants =====
            modelBuilder.Entity<Participant>().HasData(
                new Participant { Id = 1, Name = "SuperCoolBand", Arrives_At = new DateTime(2024, 7, 10, 14, 0, 0), Contact_Number = "555-1234", Hand_Color = "Red", Notes = "Requires soundcheck at 3 PM" },
                new Participant { Id = 2, Name = "JazzMasters", Arrives_At = new DateTime(2024, 7, 11, 10, 0, 0), Contact_Number = "555-5678", Hand_Color = "Blue", Notes = "Bringing their own equipment" }
                );

            // ===== TeamMembers =====
            modelBuilder.Entity<TeamMember>().HasData(
                new TeamMember { Id = 1, Name = "Alice", Role = "Vocalist", Participant_Id = 1, Contact_Number = "555-4128"},
                new TeamMember { Id = 2, Name = "Bob", Role = "Guitarist", Participant_Id = 1, Contact_Number = "555-4312" },
                new TeamMember { Id = 3, Name = "Charlie", Role = "Saxophonist", Participant_Id = 2, Contact_Number = "555-9412" },
                new TeamMember { Id = 4, Name = "Diana", Role = "Drummer", Participant_Id = 2, Contact_Number = "555-9481" },
                new TeamMember { Id = 5, Name = "Eve", Role = "Drummer", Participant_Id = 1, Contact_Number = "555-4144" }
                );

            // ===== Accreditations =====
            modelBuilder.Entity<Accreditation>().HasData(
                new Accreditation { Id = 1, Team_Member_Id = 1, Valid_From = new DateTime(2024, 7, 9), Valid_To = new DateTime(2024, 7, 12) },
                new Accreditation { Id = 2, Team_Member_Id = 2, Valid_From = new DateTime(2024, 7, 9), Valid_To = new DateTime(2024, 7, 12) },
                new Accreditation { Id = 3, Team_Member_Id = 3, Valid_From = new DateTime(2024, 7, 10), Valid_To = new DateTime(2024, 7, 13) },
                new Accreditation { Id = 4, Team_Member_Id = 4, Valid_From = new DateTime(2024, 7, 10), Valid_To = new DateTime(2024, 7, 13) },
                new Accreditation { Id = 5, Team_Member_Id = 5, Valid_From = new DateTime(2024, 7, 9), Valid_To = new DateTime(2024, 7, 12) }
                );

            // ===== Stages =====
            modelBuilder.Entity<Stage>().HasData(
                new Stage { Id = 1, Name = "Main Stage", Location = "Central Park", Capacity = 5000 },
                new Stage { Id = 2, Name = "Jazz Corner", Location = "Downtown Plaza", Capacity = 1500 }
                );

            // ===== Performances =====
            modelBuilder.Entity<Performance>().HasData(
                new Performance { Id = 1, Participant_Id = 1, Stage_Id = 1, Starts_At = new DateTime(2024, 7, 10, 18, 0, 0), Ends_At = new DateTime(2024, 7, 10, 19, 30, 0) },
                new Performance { Id = 2, Participant_Id = 2, Stage_Id = 2, Starts_At = new DateTime(2024, 7, 11, 20, 0, 0), Ends_At = new DateTime(2024, 7, 11, 21, 30, 0) }
                );

            // ===== TechnicalBreaks =====
            modelBuilder.Entity<TechnicalBreak>().HasData(
                new TechnicalBreak { Id = 1, Stage_Id = 1, Starts_At = new DateTime(2024, 7, 10, 19, 30, 0), Ends_At = new DateTime(2024, 7, 10, 20, 0, 0) }
                );

            // ===== Volunteers =====
            modelBuilder.Entity<Volunteer>().HasData(
                new Volunteer { Id = 1, Name = "Frank", Contact_Number = "555-7777", Role = "Stage helper" },
                new Volunteer { Id = 2, Name = "Grace", Contact_Number = "555-8888", Role = "Crowd control" }
                );
            
            // ===== Zones =====
            modelBuilder.Entity<Zone>().HasData(
                new Zone { Id = 1, Name = "Backstage", Type = "Restricted", Location = "Behind Main Stage" },
                new Zone { Id = 2, Name = "Entrance", Type = "Public", Location = "North Gate" },
                new Zone { Id = 3, Name = "Food Court", Type = "Public", Location = "East Side" }
                );

            // ===== VolunteerShifts =====
            modelBuilder.Entity<VolunteerShift>().HasData(
                new VolunteerShift { Id = 1, Volunteer_Id = 1, Starts_At = new DateTime(2024, 7, 10, 16, 0, 0), Ends_At = new DateTime(2024, 7, 10, 22, 0, 0), Zone_Id = 1},
                new VolunteerShift { Id = 2, Volunteer_Id = 2, Starts_At = new DateTime(2024, 7, 11, 18, 0, 0), Ends_At = new DateTime(2024, 7, 11, 23, 0, 0), Zone_Id = 2}
                );

            // ===== Partners =====
            modelBuilder.Entity<Partner>().HasData(
                new Partner { Id = 1, Name = "City Radio", Contact_Number = "555-2222" },
                new Partner { Id = 2, Name = "Local Eats", Contact_Number = "555-3333" }
                );

            // ===== ActivationZones =====
            modelBuilder.Entity<ActivationZone>().HasData(
                new ActivationZone { Id = 1, Partner_Id = 1, Zone_Id = 2, Required_Power = 500, Notes = "Setup live broadcast point" },
                new ActivationZone { Id = 2, Partner_Id = 2, Zone_Id = 3, Required_Power = 200, Notes = "Food stalls area" }
                );

            // ===== LogisticItems =====
            modelBuilder.Entity<LogisticItem>().HasData(
                new LogisticItem { Id = 1, Name = "Speaker System", Quantity = 10, Zone_Id = 1 },
                new LogisticItem { Id = 2, Name = "Lighting Rig", Quantity = 5, Zone_Id = 1 },
                new LogisticItem { Id = 3, Name = "Barricades", Quantity = 50, Zone_Id = 2 }
                );

            // ===== Tickets =====
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { Id = 1, Qr_Code = "TICKET12345", Type = "VIP", Buyer_Name = "John Doe", Contact_Number = "555-6666", Entrance_Date = null, Status = "Unused" },
                new Ticket { Id = 2, Qr_Code = "TICKET67890", Type = "General", Buyer_Name = "Jane Smith", Contact_Number = "555-7777", Entrance_Date = null, Status = "Unused" },
                new Ticket { Id = 3, Qr_Code = "TICKET54321", Type = "General", Buyer_Name = "Mike Johnson", Contact_Number = "555-8888", Entrance_Date = null, Status = "Unused" }
                );

            // ===== Incidents =====
            modelBuilder.Entity<Incident>().HasData(
                new Incident { Id = 1, Zone_Id = 2, Ticket_Id = 1, Happened_At = new DateTime(2024, 7, 10, 19, 0, 0), Description = "Lost ticket" },
                new Incident { Id = 2, Zone_Id = 3, Ticket_Id = 2, Happened_At = new DateTime(2024, 7, 11, 20, 30, 0), Description = "Medical emergency" }
                );

            // ===== DailyReports =====
            modelBuilder.Entity<DailyReport>().HasData(
                new DailyReport { Id = 1, Date = new DateTime(2024, 7, 10), Summary = "Successful opening day with great performances.", Contents = "The festival kicked off with SuperCoolBand delivering an electrifying performance on the Main Stage. Attendance was high, and the crowd was enthusiastic. Minor incidents included a lost ticket at the entrance, which was resolved quickly." },
                new DailyReport { Id = 2, Date = new DateTime(2024, 7, 11), Summary = "Second day focused on jazz with smooth performances.", Contents = "JazzMasters captivated the audience at the Jazz Corner with their soulful tunes. The atmosphere was relaxed and enjoyable. A medical emergency was handled efficiently by the on-site team, ensuring the safety of all attendees." }
                );
        }
    }
}
