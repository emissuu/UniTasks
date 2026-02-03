using Data.Models;

namespace Repositories.Interfaces
{
    public interface ITeamRepository : IRepository<Team>
    {
        public void AddTeamUser(TeamUser teamUser);
        public Team? GetByIdSimple(int id);
        public Team? GetByName(string name);
    }
}
