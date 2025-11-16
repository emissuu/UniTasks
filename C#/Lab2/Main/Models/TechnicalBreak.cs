using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Main.Models
{
    public class TechnicalBreak
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime? Starts_At { get; set; }
        public DateTime? Ends_At { get; set; }
        public string? Notes { get; set; }

        [Required]
        public int Stage_Id { get; set; }
        [ForeignKey(nameof(Stage_Id))]
        public Stage Stage { get; set; } = default!;
    }
}
