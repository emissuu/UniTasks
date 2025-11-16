using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Main.Models
{
    public class VolunteerShift
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime? Starts_At { get; set; }
        public DateTime? Ends_At { get; set; }

        [Required]
        public int Volunteer_Id { get; set; }
        [ForeignKey(nameof(Volunteer_Id))]
        public Volunteer Volunteer { get; set; } = default!;
        [Required]
        public int Zone_Id { get; set; }
        [ForeignKey(nameof(Zone_Id))]
        public Zone Zone { get; set; } = default!;
    }
}
