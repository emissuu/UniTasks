using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }

        [Required]
        public int AdministratorId { get; set; }
        [ForeignKey(nameof(AdministratorId))]
        public Administrator Administrator { get; set; }

        public virtual ICollection<EventBlock> EventBlocks { get; set; } = new List<EventBlock>();
        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
