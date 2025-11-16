using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Models
{
    public class ActivationZone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? Required_Power { get; set; }
        public string? Notes { get; set; }

        [Required]
        public int Partner_Id { get; set; }
        [ForeignKey(nameof(Partner_Id))]
        public Partner Partner { get; set; } = default!;
        [Required]
        public int Zone_Id { get; set; }
        [ForeignKey(nameof(Zone_Id))]
        public Zone Zone { get; set; } = default!;
    }
}
