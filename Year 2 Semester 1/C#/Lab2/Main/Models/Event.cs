using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }

        [Required]
        public int AdministratorId { get; set; }
        [ForeignKey(nameof(AdministratorId))]
        public Administrator Administrator { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public virtual ICollection<ZoneActivation> ZoneActivations { get; set; } = new List<ZoneActivation>();
    }
}
