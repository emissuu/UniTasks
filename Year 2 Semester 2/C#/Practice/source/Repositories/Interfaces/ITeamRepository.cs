using Data.Models;

namespace Repositories.Interfaces
{
    public interface ITeamRepository : IRepository<Team>
    {
        public void AddTeamUser(TeamUser teamUser);
    }
}
