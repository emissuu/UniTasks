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
            List<Participant> participants = context.Participants
                .Where(a => a.Id == 1)
                .ToList();
            Console.WriteLine("Participants with Id = 1:");
            foreach (var participant in participants)
                Console.WriteLine($"Id {participant.Id}. Participant: {participant.Name}, Contact phone: {participant.Contact_Number}");

            // ===== FindOrDefault =====
            Console.WriteLine("\n2. FirstOrDefault");
            TeamMember teamMember = context.TeamMembers
                .FirstOrDefault(a => a.Id == 6);
            if (teamMember != null) Console.WriteLine($"Team Member with Id = 6: {teamMember.Name}");
            else Console.WriteLine("Team Member with Id = 6 not found.");

            // ===== Include =====
            Console.WriteLine("\n3. Include");
            List<TeamMember> teamMembers = context.TeamMembers
                .Include(a => a.Participant)
                .ToList();
            Console.WriteLine("Team Members with Participant included:");
            foreach (var member in teamMembers)
                Console.WriteLine($"Id {member.Id}. Team Member: {member.Name} is a member of {member.Participant.Name}");

            // ===== OrderBy =====
            Console.WriteLine("\n4. OrderBy");
            List<Accreditation> accreditations = context.Accreditations
                .OrderBy(a => a.Valid_To)
                .Include(a => a.Team_Member)
                .ToList();
            Console.WriteLine("Accreditations sorted by valid_to:");
            foreach (var accreditation in accreditations)
                Console.WriteLine($"Id {accreditation.Id}. Team Member: {accreditation.Team_Member.Name}, Valid To: {accreditation.Valid_To}");

            // ===== Average =====
            Console.WriteLine("\n5. Average");
            double? averagePerformances = context.Performances
                .Average(a => EF.Functions.DateDiffMinute(a.Starts_At, a.Ends_At));
            Console.WriteLine($"Average performance duration in minutes: {averagePerformances}");
        }
    }
}