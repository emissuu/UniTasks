using Main.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

class Program
{
    static void Main()
    {
        using (var context = new Main.Context.AppDbContext())
        {
            // ===== Where =====
            Console.WriteLine("1. Where");
            List<Team> participants = context.Teams
                .Where(a => a.Id == 1 || a.Id == 3)
                .ToList();
            Console.WriteLine($"Teams with Id = 1 or Id = 3:");
            foreach (var team in participants)
                Console.WriteLine($"Id {team.Id}. Team: {team.Name}, Contact number: {team.ContactNumber}");

            // ===== FirstOrDefault =====
            Console.WriteLine("\n2. FirstOrDefault");
            Team? team1 = context.Teams
                .FirstOrDefault(a => a.Id == 2);
            if (team1 != null) Console.WriteLine($"Team with Id = 2: {team1.Name}, Contact number: {team1.ContactNumber}");
            else Console.WriteLine("Team with Id = 2 not found");

            // ===== Include =====
            Console.Write("\n3. Include");
            List<Team> teamsWithMembers = context.Teams
                .Include(t => t.TeamMembers)
                .ThenInclude(tm => tm.Ticket)
                .ToList();
            foreach (var team in teamsWithMembers)
            {
                Console.WriteLine($"\nTeam: {team.Name}");
                foreach (var member in team.TeamMembers)
                    Console.WriteLine($" - Member: {member.Ticket.BuyerName}, Role: {member.Role}, Contact number: {member.Ticket.BuyerContactNumber}");
            }

            // ===== OrderBy =====
            Console.WriteLine("\n4. OrderBy");
            List<Team> teamsOrdered = context.Teams
                .OrderBy(t => t.Name)
                .ToList();
            Console.WriteLine("Teams ordered by Name:");
            foreach (var team in teamsOrdered)
                Console.WriteLine($"Id {team.Id}. Team: {team.Name}, Contact number: {team.ContactNumber}");

            // ===== Average =====
            Console.WriteLine("\n5. Average");
            // average performance duration counting from StartsAt to EndsAt in EventBlocks
            double? averageDuration = context.EventBlocks
                .Where(e => e.Type == "Performance")
                .Average(eb => EF.Functions.DateDiffMinute(eb.StartsAt, eb.EndsAt));
            Console.WriteLine($"Average performance duration: {averageDuration} minutes");
        }
    }
}