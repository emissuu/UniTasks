using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Models
{
    public class Volunteer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Contact_Number { get; set; }
        public string? Role { get; set; }

        public ICollection<VolunteerShift> Volunteer_Shifts { get; set; } = new List<VolunteerShift>();
    }
}
