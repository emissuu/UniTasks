namespace Services.Models
{
    public class TaskDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int CreatedById { get; set; }
        public int AssignedToId { get; set; }
        public int StatusId { get; set; }
        public string Name { get; set; } = null!;
        public string Details { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DueDate { get; set; }
        public TaskDto(int id, int projectId, int createdById, int assignedToId, int statusId, string name, string details, DateTime createdAt, DateTime updatedAt, DateTime dueDate)
        {
            Id = id;
            ProjectId = projectId;
            CreatedById = createdById;
            AssignedToId = assignedToId;
            StatusId = statusId;
            Name = name;
            Details = details;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            DueDate = dueDate;
        }
    }
}
