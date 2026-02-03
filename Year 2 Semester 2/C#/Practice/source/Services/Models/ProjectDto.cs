namespace Services.Models
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public int CreatedById { get; set; }
        public int? TeamId { get; set; }
        public string Name { get; set; } = null!;
        public string? Details { get; set; }
        public DateTime CreatedAt { get; set; }
        public ProjectDto(int id, int createdById, int? teamId, string name, string? details, DateTime createdAt)
        {
            Id = id;
            CreatedById = createdById;
            TeamId = teamId;
            Name = name;
            Details = details;
            CreatedAt = createdAt;
        }
    }
}
