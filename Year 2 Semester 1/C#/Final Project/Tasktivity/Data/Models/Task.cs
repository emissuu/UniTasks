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
        [StringLength(64)]
        public string Name { get; set; }
        [StringLength(32768)]
        public string? Notes { get; set; }
        [Required]
        public DateTimeOffset WhenTo { get; set; }
        [Required]
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? CompletedAt { get; set; }
        [Required]
        public bool IsExpAcquired { get; set; }


        [Required]
        public int SizeId { get; set; }
        [ForeignKey(nameof(SizeId))]
        public TaskSize Size { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
    }
}
