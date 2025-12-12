using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Theme
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [Required]
        public string Accent { get; set; }
        [Required]
        public string Foreground { get; set; }
        [Required]
        public string SubForeground { get; set; }
        [Required]
        public string Background { get; set; }
        [Required]
        public string SubBackground { get; set; }
        [Required]
        public string SubSubBackground { get; set; }

        public virtual User? User { get; set; }
    }
}
