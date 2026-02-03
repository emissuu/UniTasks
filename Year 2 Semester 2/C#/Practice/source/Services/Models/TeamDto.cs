namespace Services.Models
{
    public class TeamDto
    {
        public int Id { get; set; }
        public int CreatedById { get; set; }
        public string Name { get; set; } = null!;
        public TeamDto(int id, int createdById, string name)
        {
            Id = id;
            Name = name;
            CreatedById = createdById;
        }
    }
}
