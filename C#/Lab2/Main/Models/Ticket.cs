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
        public string Qr_Code { get; set; }
        public string? Type { get; set; }
        public string? Buyer_Name { get; set; }
        public string? Contact_Number { get; set; }
        public DateTime? Entrance_Date { get; set; }
        public string? Status { get; set; }

        public ICollection<Incident> Incidents { get; set; } = new List<Incident>();
    }
}
