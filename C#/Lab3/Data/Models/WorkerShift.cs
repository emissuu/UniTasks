using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
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
        public Worker Worker { get; set; } = null!;
        [Required]
        public int EventBlockId { get; set; }
        [ForeignKey(nameof(EventBlockId))]
        public EventBlock EventBlock { get; set; } = null!;
    }
}
