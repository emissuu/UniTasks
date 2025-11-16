using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Main.Models
{
    public class Participant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Transport { get; set; }
        public DateTime? Arrives_At { get; set; }
        public string? Hand_Color { get; set; }
        public string? Contact_Number { get; set; }
        public string? Notes { get; set; }

        public ICollection<TeamMember> Team_Members { get; set; } = new List<TeamMember>();
        public ICollection<Performance> Performances { get; set; } = new List<Performance>();
    }
}
