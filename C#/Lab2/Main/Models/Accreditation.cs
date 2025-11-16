using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Models
{
    public class Accreditation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime? Valid_From{ get; set; }
        public DateTime? Valid_To { get; set; }

        [Required]
        public int Team_Member_Id { get; set; }
        [ForeignKey(nameof(Team_Member_Id))]
        public TeamMember Team_Member { get; set; } = default!;
    }
}
