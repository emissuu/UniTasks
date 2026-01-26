using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int CreatedById { get; set; }
        [ForeignKey(nameof(CreatedById))]
        public virtual User CreatedBy { get; set; } = null!;

        public int? TeamId { get; set; }
        [ForeignKey(nameof(TeamId))]
        public virtual Team? Team { get; set; } = null!;

        [Required]
        public int StatusId { get; set; }
        [ForeignKey(nameof(StatusId))]
        public virtual Status Status { get; set; } = null!;

        [Required]
        [StringLength(32)]
        public string Name { get; set; } = null!;

        [StringLength(1024)]
        public string? Details { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public string Color { get; set; } = null!;

        public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}
