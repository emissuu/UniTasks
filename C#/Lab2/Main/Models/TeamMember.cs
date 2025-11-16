using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Models
{
    public class TeamMember
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Role { get; set; }
        public string? Contact_Number { get; set; }

        [Required]
        public int Participant_Id { get; set; }
        [ForeignKey(nameof(Participant_Id))]
        public Participant Participant { get; set; } = default!;

        public ICollection<Accreditation> Accreditations { get; set; } = new List<Accreditation>();
    }
}
