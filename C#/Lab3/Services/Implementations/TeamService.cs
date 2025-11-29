using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class TeamService
    {
        private readonly TeamRepository _repo;
        public TeamService(TeamRepository repo) => _repo = repo;
    }
}
