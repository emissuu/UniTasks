using Data.Models;
using Services.Models;

namespace Services.Interfaces
{
    public interface ITeamService
    {
        public IEnumerable<Team> GetAll();
        public Team GetById(int id);
        public void Add(Team team, int userId);
        public void Update(Team team, int userId);
        public void Remove(int[] ids, int userId);
        public void AddTeamUsers(List<TeamUser> teamUsers);
        public IEnumerable<TeamDetails> GetAllTeamDetails();
    }
}
