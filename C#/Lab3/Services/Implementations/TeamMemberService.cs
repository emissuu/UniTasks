using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class TeamMemberService
    {
        private readonly TeamMemberRepository _repo;
        public TeamMemberService(TeamMemberRepository repo) => _repo = repo;
    }
}
