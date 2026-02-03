namespace Services.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserDto(int id, int roleId, string userName, string? phoneNumber, string? email, DateTime createdAt)
        {
            Id = id;
            RoleId = roleId;
            UserName = userName;
            PhoneNumber = phoneNumber;
            Email = email;
            CreatedAt = createdAt;
        }
    }
}
