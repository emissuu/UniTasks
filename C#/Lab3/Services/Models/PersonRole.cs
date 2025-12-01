using Data.Models;

namespace Services.Models
{
    public class PersonRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }

        public Administrator? Administrator { get; set; }
        public Worker? Worker { get; set; }
        public TeamMember? Guest { get; set; }

        public string? Role
        {
            get
            {
                if (Administrator != null)
                    return "Administrator";
                else if (Worker != null)
                    return "Worker";
                else if (Guest != null)
                    return "Guest";
                else
                    return null;
            }
        }
    }
}
