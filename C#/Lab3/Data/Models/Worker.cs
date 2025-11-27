using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Worker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Role { get; set; }
        public int? Salary { get; set; }

        [Required]
        public int PersonId { get; set; }
        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; } = null!;

        public virtual ICollection<WorkerShift> WorkerShifts { get; set; } = new List<WorkerShift>();
    }
}
