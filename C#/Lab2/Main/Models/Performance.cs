using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Models
{
    public class Performance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime? Starts_At { get; set; }
        public DateTime? Ends_At { get; set ;}

        [Required]
        public int Participant_Id { get; set; }
        [ForeignKey(nameof(Participant_Id))]
        public Participant Participant { get; set; } = default!;
        [Required]
        public int Stage_Id { get; set; }
        [ForeignKey(nameof(Stage_Id))]
        public Stage Stage { get; set; } = default!;
    }
}
