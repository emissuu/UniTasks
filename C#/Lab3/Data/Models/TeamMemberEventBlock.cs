using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class TeamMemberEventBlock
    {
        [Key, Column(Order = 0)]
        public int TeamMemberId { get; set; }
        [ForeignKey(nameof(TeamMemberId))]
        public TeamMember TeamMember { get; set; } = null!;

        [Key, Column(Order = 1)]
        public int EventBlockId { get; set; }
        [ForeignKey(nameof(EventBlockId))]
        public EventBlock EventBlock { get; set; } = null!;
    }
}
