using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Incident
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public DateTime? HappenedAt { get; set; }
        [Required]
        public bool IsResolved { get; set; }

        [Required]
        public int TicketId { get; set; }
        [ForeignKey(nameof(TicketId))]
        public Ticket Ticket { get; set; }


        [NotMapped]
        public string Resolvation
        {
            get => IsResolved ? "Resolved" : "Unresolved";
        }

    }
}
