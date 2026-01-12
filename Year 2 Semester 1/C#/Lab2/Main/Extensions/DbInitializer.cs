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
            // ===== Administrators =====
            modelBuilder.Entity<Administrator>().HasData(
                new Administrator { Id = 1, Name = "Bohdan", ContactNumber = "054-5417" }
                );

            // ===== Events =====
            modelBuilder.Entity<Event>().HasData(
                new Event { Id = 1, Name = "Summer Rock Festival", Date = new DateTime(2024, 8, 15), Description = "An electrifying rock music festival featuring top bands from around the world.", AdministratorId = 1 },
                new Event { Id = 2, Name = "Winter Jazz Nights", Date = new DateTime(2024, 12, 5), Description = "A cozy jazz event to warm up your winter nights with smooth tunes.", AdministratorId = 1 }
                );

            // ===== Teams =====
            modelBuilder.Entity<Team>().HasData(
                new Team { Id = 1, Name = "The Rockers", ContactNumber = "054-5441", Transport = "Bus", ArrivesAt = new DateTime(2024, 8, 14, 10, 0, 0), HandColor = "Red", Notes = "Requires backstage access." },
                new Team { Id = 2, Name = "Jazz Masters", ContactNumber = "054-5499", Transport = "Van", ArrivesAt = new DateTime(2024, 12, 4, 15, 0, 0), HandColor = "Blue", Notes = "Needs special sound equipment." },
                new Team { Id = 3, Name = "Fire Jazz", ContactNumber = "054-5490", Transport = "Car", ArrivesAt = new DateTime(2024, 12, 4, 12, 0, 0), HandColor = "Green", Notes = "Bringing their own instruments." }
                );

            // ===== Tickets =====
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { Id = 1, EventId = 1, QrCode = "QR123456", BuyerName = "Alice Johnson", BuyerContactNumber = "054-5001" },
                new Ticket { Id = 2, EventId = 1, QrCode = "QR123457", BuyerName = "Bob Smith", BuyerContactNumber = "054-5002" },
                new Ticket { Id = 3, EventId = 2, QrCode = "QR223456", BuyerName = "Charlie Brown", BuyerContactNumber = "054-6001" },
                new Ticket { Id = 4, EventId = 2, QrCode = "QR223457", BuyerName = "Diana Prince", BuyerContactNumber = "054-6002" },
                new Ticket { Id = 5, EventId = 2, QrCode = "QR223458", BuyerName = "Ethan Hunt", BuyerContactNumber = "054-6003" },
                new Ticket { Id = 6, EventId = 1, QrCode = "QR123458", BuyerName = "Fiona Glenanne", BuyerContactNumber = "054-5003" },
                new Ticket { Id = 7, EventId = 1, QrCode = "QR123459", BuyerName = "George Clooney", BuyerContactNumber = "054-5004" }
                );

            // ===== Team Members =====
            modelBuilder.Entity<TeamMember>().HasData(
                new TeamMember { Id = 1, Role = "Guitarist", TeamId = 1, TicketId = 1 },
                new TeamMember { Id = 2, Role = "Drummer", TeamId = 1, TicketId = 2 },
                new TeamMember { Id = 3, Role = "Saxophonist", TeamId = 2, TicketId = 3 },
                new TeamMember { Id = 4, Role = "Vocalist", TeamId = 2, TicketId = 4 },
                new TeamMember { Id = 5, Role = "Vocalist", TeamId = 3, TicketId = 5 }
                );

            // ===== Partners =====
            modelBuilder.Entity<Partner>().HasData(
                new Partner { Id = 1, Name = "SoundWave Co.", ContactNumber = "054-7001", Description = "Leading provider of sound equipment for events." },
                new Partner { Id = 2, Name = "EventSecure Ltd.", ContactNumber = "054-7002", Description = "Specialists in event security and crowd management." },
                new Partner { Id = 3, Name = "Foodies Inc.", ContactNumber = "054-7003", Description = "Catering services for large-scale events." }
                );

            // ===== Zones =====
            modelBuilder.Entity<Zone>().HasData(
                new Zone { Id = 1, Name = "Main Stage", Type = "Performance", Location = "Central Area" },
                new Zone { Id = 2, Name = "VIP Lounge", Type = "Exclusive", Location = "North Wing" },
                new Zone { Id = 3, Name = "Food Court", Type = "Catering", Location = "East Side" }
                );

            // ===== Zone Activations =====
            modelBuilder.Entity<ZoneActivation>().HasData(
                new ZoneActivation { Id = 1, ZoneId = 1, PartnerId = 1, EventId = 1, Notes = "Setup sound systems and lighting." },
                new ZoneActivation { Id = 2, ZoneId = 2, PartnerId = 2, EventId = 1, Notes = "Manage VIP access and security." },
                new ZoneActivation { Id = 3, ZoneId = 3, PartnerId = 3, EventId = 1, Notes = "Arrange food stalls and seating." },

                new ZoneActivation { Id = 4, ZoneId = 1, PartnerId = 1, EventId = 2, Notes = "Setup sound systems and lighting." },
                new ZoneActivation { Id = 5, ZoneId = 2, PartnerId = 2, EventId = 2, Notes = "Manage VIP access and security." },
                new ZoneActivation { Id = 6, ZoneId = 3, PartnerId = 3, EventId = 2, Notes = "Arrange food stalls and seating." }
                );

            // ===== Event Blocks =====
            modelBuilder.Entity<EventBlock>().HasData(
                new EventBlock { Id = 1, ZoneActivationId = 1, TeamId = 1, Name = "Rock Band Performance", Type = "Performance", StartsAt = new DateTime(2024, 8, 15, 18, 0, 0), EndsAt = new DateTime(2024, 8, 15, 20, 0, 0) },
                new EventBlock { Id = 2, ZoneActivationId = 1, TeamId = null, Name = "Intermission", Type = "Break", StartsAt = new DateTime(2024, 8, 15, 20, 0, 0), EndsAt = new DateTime(2024, 8, 15, 20, 30, 0) },
                new EventBlock { Id = 3, ZoneActivationId = 1, TeamId = 1, Name = "Closing Act", Type = "Performance", StartsAt = new DateTime(2024, 8, 15, 20, 30, 0), EndsAt = new DateTime(2024, 8, 15, 22, 0, 0) },

                new EventBlock { Id = 4, ZoneActivationId = 4, TeamId = 2, Name = "Jazz Evening", Type = "Performance", StartsAt = new DateTime(2024, 12, 5, 19, 0, 0), EndsAt = new DateTime(2024, 12, 5, 21, 0, 0) },
                new EventBlock { Id = 5, ZoneActivationId = 4, TeamId = null, Name = "Intermission", Type = "Break", StartsAt = new DateTime(2024, 12, 5, 21, 0, 0), EndsAt = new DateTime(2024, 12, 5, 21, 30, 0) },
                new EventBlock { Id = 6, ZoneActivationId = 4, TeamId = 3, Name = "Late Night Jazz", Type = "Performance", StartsAt = new DateTime(2024, 12, 5, 21, 30, 0), EndsAt = new DateTime(2024, 12, 5, 23, 0, 0) }
                );

            // ===== Workers =====
            modelBuilder.Entity<Worker>().HasData(
                new Worker { Id = 1, Name = "John Doe", ContactNumber = "054-8001", Role = "Sound Technician", Salary = 12000 },
                new Worker { Id = 2, Name = "Jane Smith", ContactNumber = "054-8002", Role = "Security Staff", Salary = 10000 },
                new Worker { Id = 3, Name = "Mike Johnson", ContactNumber = "054-8003", Role = "Catering Staff", Salary = 9000 }
                );

            // ===== Worker Shifts =====
            modelBuilder.Entity<WorkerShift>().HasData(
                new WorkerShift { Id = 1, WorkerId = 1, ZoneActivationId = 1, StartsAt = new DateTime(2024, 8, 15, 16, 0, 0), EndsAt = new DateTime(2024, 8, 15, 23, 0, 0) },
                new WorkerShift { Id = 2, WorkerId = 2, ZoneActivationId = 2, StartsAt = new DateTime(2024, 8, 15, 17, 0, 0), EndsAt = new DateTime(2024, 8, 15, 23, 0, 0) },
                new WorkerShift { Id = 3, WorkerId = 3, ZoneActivationId = 3, StartsAt = new DateTime(2024, 8, 15, 15, 0, 0), EndsAt = new DateTime(2024, 8, 15, 22, 0, 0) },
                new WorkerShift { Id = 4, WorkerId = 1, ZoneActivationId = 4, StartsAt = new DateTime(2024, 12, 5, 17, 0, 0), EndsAt = new DateTime(2024, 12, 5, 23, 0, 0) },
                new WorkerShift { Id = 5, WorkerId = 2, ZoneActivationId = 5, StartsAt = new DateTime(2024, 12, 5, 18, 0, 0), EndsAt = new DateTime(2024, 12, 5, 23, 0, 0) },
                new WorkerShift { Id = 6, WorkerId = 3, ZoneActivationId = 6, StartsAt = new DateTime(2024, 12, 5, 16, 0, 0), EndsAt = new DateTime(2024, 12, 5, 22, 0, 0) }
                );

            // ===== Incidents =====
            modelBuilder.Entity<Incident>().HasData(
                new Incident { Id = 1, TicketId = 1, Type = "Lost Item", Description = "Lost sunglasses during the event.", HappenedAt = new DateTime(2024, 8, 15, 19, 30, 0), IsResolved = true },
                new Incident { Id = 2, TicketId = 4, Type = "Medical Emergency", Description = "Attendee fainted and required medical attention.", HappenedAt = new DateTime(2024, 12, 5, 20, 15, 0), IsResolved = true },
                new Incident { Id = 3, TicketId = 6, Type = "Ticket Issue", Description = "QR code not scanning at entry.", HappenedAt = new DateTime(2024, 8, 15, 17, 45, 0), IsResolved = false }
                );
        }
    }
}
