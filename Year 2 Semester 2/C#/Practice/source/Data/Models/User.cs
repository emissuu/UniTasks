using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; } = null!;

        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string UserName { get; set; } = null!;

        [StringLength(14)]
        public string? PhoneNumber{ get; set; }

        [StringLength(255)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string PasswordHash { get; set; } = null!;

        [Required]
        public DateTime CreatedAt { get; set; }
        
        public virtual ICollection<TeamUser> TeamUsers { get; set; } = new List<TeamUser>();

        public virtual ICollection<Team> CreatedTeams { get; set; } = new List<Team>();

        public virtual ICollection<Project> CreatedProjects { get; set; } = new List<Project>();

        public virtual ICollection<Task> CreatedTasks { get; set; } = new List<Task>();

        public virtual ICollection<Task> AssignedTasks { get; set; } = new List<Task>();

        public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();
    }
}