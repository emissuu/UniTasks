using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class TeamRepository : Repository<Team>
    {
        public TeamRepository(DbContext context) : base(context) { }
    }
}
