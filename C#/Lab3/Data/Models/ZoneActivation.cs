using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class ZoneActivation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Notes { get; set; }

        [Required]
        public int ZoneId { get; set; }
        [ForeignKey(nameof(ZoneId))]
        public Zone Zone { get; set; } = null!;
        [Required]
        public int EventBlockId { get; set; }
        [ForeignKey(nameof(EventBlockId))]
        public EventBlock EventBlock { get; set; } = null!;
        public int? PartnerId { get; set; }
        [ForeignKey(nameof(PartnerId))]
        public Partner? Partner { get; set; } = null!;
    }
}
