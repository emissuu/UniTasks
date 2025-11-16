using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Main.Models
{
    public class Stage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Location { get; set; }
        public int? Capacity { get; set; }

        public ICollection<Performance> Performances { get; set; } = new List<Performance>();
        public ICollection<TechnicalBreak> TechnicalBreaks { get; set; } = new List<TechnicalBreak>();
    }
}
