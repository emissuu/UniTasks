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
        [Required]
        [StringLength(32, MinimumLength = 3)]
        public string UserName { get; set; }
        [Required]
        [StringLength(12)]
        public string PhoneNumber{ get; set; }
        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(64)]
        public string PasswordHash { get; set; }
        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }
    }
}