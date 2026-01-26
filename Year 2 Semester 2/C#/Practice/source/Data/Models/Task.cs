using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ProjectId { get; set; }
        [ForeignKey(nameof(ProjectId))]
        public virtual Project Project { get; set; } = null!;

        [Required]
        public int CreatedById { get; set; }
        [ForeignKey(nameof(CreatedById))]
        public virtual User CreatedBy { get; set; } = null!;

        [Required]
        public int AssignedToId { get; set; }
        [ForeignKey(nameof(AssignedToId))]
        public virtual User AssignedTo { get; set; } = null!;

        [Required]
        public int StatusId { get; set; }
        [ForeignKey(nameof(StatusId))]
        public virtual Status Status { get; set; } = null!;

        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        [StringLength(1024)]
        public string Details { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        [Required]
        public DateTime DueDate { get; set; }
    }
}
