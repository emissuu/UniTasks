using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class TeamMemberRepository : Repository<TeamMember>
    {
        public TeamMemberRepository(DbContext context) : base(context) { }
    }
}
