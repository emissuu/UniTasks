using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Models
{
    public class Incident
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public DateTime? Happened_At { get; set; }

        [Required]
        public int Zone_Id { get; set; }
        [ForeignKey(nameof(Zone_Id))]
        public Zone Zone { get; set; } = default!;
        [Required]
        public int Ticket_Id { get; set; }
        [ForeignKey(nameof(Ticket_Id))]
        public Ticket Ticket { get; set; } = default!;
    }
}
