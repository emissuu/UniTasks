using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string QrCode { get; set; }
        [Required]
        public string BuyerName { get; set; }
        public string? BuyerContactNumber { get; set; }

        [Required]
        public int EventId { get; set; }
        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; }

        public virtual TeamMember? TeamMember { get; set; }
        public virtual ICollection<Incident> Incidents { get; set; } = new List<Incident>();
    }
}
