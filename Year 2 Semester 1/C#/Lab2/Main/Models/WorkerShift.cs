using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Models
{
    public class WorkerShift
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime? StartsAt { get; set; }
        public DateTime? EndsAt { get; set; }

        [Required]
        public int WorkerId { get; set; }
        [ForeignKey(nameof(WorkerId))]
        public Worker Worker { get; set; }
        [Required]
        public int ZoneActivationId { get; set; }
        [ForeignKey(nameof(ZoneActivationId))]
        public ZoneActivation ZoneActivation { get; set; }
    }
}
