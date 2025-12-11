using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? UserName { get; set; }
        [Required]
        public int TotalExperience { get; set; }
        [Required]
        public int TasksCompleted { get; set; }
        [Required]
        public DateTimeOffset CreatedAt { get; set; }

        [Required]
        public int ActiveThemeId { get; set; }
        [ForeignKey(nameof(ActiveThemeId))]
        public Theme ActiveTheme { get; set; }
    }
}
