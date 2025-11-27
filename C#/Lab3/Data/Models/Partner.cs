using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Partner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? ContactNumber { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<ZoneActivation> ZoneActivations { get; set; } = new List<ZoneActivation>();
    }
}
