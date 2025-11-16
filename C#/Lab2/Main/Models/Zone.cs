using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Models
{
    public class Zone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Type { get; set; }
        public string? Location { get; set; }

        public ICollection<VolunteerShift> Volunteer_Shifts { get; set; } = new List<VolunteerShift>();
        public ICollection<ActivationZone> Activation_Zones { get; set; } = new List<ActivationZone>();
        public ICollection<LogisticItem> Logistic_Items { get; set; } = new List<LogisticItem>();
        public ICollection<Incident> Incidents { get; set; } = new List<Incident>();
    }
}
