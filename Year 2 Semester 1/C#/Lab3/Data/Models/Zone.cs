using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Zone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Type { get; set; }
        public string? Location { get; set; }

        public virtual ICollection<ZoneActivation> ZoneActivations { get; set; } = new List<ZoneActivation>();
    }
}
