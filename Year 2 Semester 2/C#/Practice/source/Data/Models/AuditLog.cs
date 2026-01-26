using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class AuditLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; } = null!;

        [Required]
        [StringLength(128)]
        public string EntityType { get; set; }

        [Required]
        public int EntityId { get; set; }

        [Required]
        [StringLength(16)]
        public string Action{ get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public string? OldValue { get; set; }

        public string? NewValue { get; set; }
    }
}
