using Data.Models;
using System.Windows;

namespace Services.Models
{
    public class TeamDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User CreatedBy { get; set; }
        public List<TeamUser> TeamUsers { get; set; }

        public bool Selection = false;
        public TeamDetails(int id, string name, User createdBy, List<TeamUser> teamUsers)
        {
            Id = id;
            Name = name;
            CreatedBy = createdBy;
            TeamUsers = teamUsers
                .OrderBy(tu => tu.User.RoleId)
                .ThenBy(tu => tu.User.UserName)
                .ToList();
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
        public override string ToString()
        {
            return Name;
        }
    }
}
