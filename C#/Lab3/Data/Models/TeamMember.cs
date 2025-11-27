using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class TeamMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Role { get; set; }

        [Required]
        public int PersonId { get; set; }
        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; } = null!;
        [Required]
        public int TeamId { get; set; }
        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; } = null!;

        public virtual ICollection<EventBlock> EventBlocks { get; set; } = new List<EventBlock>();
        public virtual ICollection<TeamMemberEventBlock> TeamMemberEventBlocks { get; set; } = new List<TeamMemberEventBlock>();
    }
}
