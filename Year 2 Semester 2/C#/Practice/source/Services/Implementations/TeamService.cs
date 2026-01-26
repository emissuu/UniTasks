using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }
        // Stuff will be written here shortly
    }
}
