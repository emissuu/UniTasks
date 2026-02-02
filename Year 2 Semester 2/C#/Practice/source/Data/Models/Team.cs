using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int CreatedById { get; set; }
        [ForeignKey(nameof(CreatedById))]
        public virtual User CreatedBy { get; set; } = null!;

        [Required]
        [StringLength(32)]
        public string Name { get; set; } = null!;

        public virtual ICollection<TeamUser> TeamUsers { get; set; } = new List<TeamUser>();

        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
