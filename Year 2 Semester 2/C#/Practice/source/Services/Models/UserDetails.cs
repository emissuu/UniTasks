using Data.Models;

namespace Services.Models
{
    public class UserDetails
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public Role Role { get; set; }
        public DateTime CreatedAt { get; set; }

        public bool Selection = false;
        public UserDetails(int id, string userName, string? email, string? phoneNumber, Role role, DateTime createdAt)
        {
            Id = id;
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
            Role = role;
            CreatedAt = createdAt;
        }
        public string GetEmail
        {
            get
            {
                if (Email == null)
                    return "<No email address>";
                return Email;
            }
        }
        public string GetPhoneNumber
        {
            get
            {
                if (PhoneNumber == null)
                    return "<No phone number>";
                return PhoneNumber;
            }
        }
        public string GetCreatedAt
        {
            get
            {
                return "Date Joined: " + CreatedAt
                    .ToLocalTime()
                    .ToString("g");
            }
        }
        public bool IsChecked
        {
            get
            {
                return Selection;
            }
            set
            {
                Selection = value;
            }
        }
        public User ToUser()
        {
            return new User()
            {
                Id = Id,
                UserName = UserName,
                Email = Email,
                PhoneNumber = PhoneNumber,
                RoleId = Role.Id,
                Role = Role,
                CreatedAt = CreatedAt
            };
        }
    }
}
