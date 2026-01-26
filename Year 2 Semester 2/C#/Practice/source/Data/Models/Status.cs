using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(32)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
        public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}
