using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(DbContext context) : base(context) { }
    }
}
