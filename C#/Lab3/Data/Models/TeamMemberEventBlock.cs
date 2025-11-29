using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class TeamMemberEventBlock
    {
        public int TeamMemberId { get; set; }
        [ForeignKey(nameof(TeamMemberId))]
        public TeamMember TeamMember { get; set; } = null!;

        public int EventBlockId { get; set; }
        [ForeignKey(nameof(EventBlockId))]
        public EventBlock EventBlock { get; set; } = null!;
    }
}
