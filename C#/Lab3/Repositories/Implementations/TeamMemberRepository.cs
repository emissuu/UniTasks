using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class TeamMemberRepository : Repository<TeamMember>
    {
        public TeamMemberRepository(DbContext context) : base(context) { }
        public override void Update(TeamMember entity)
        {
            var existingPerson = _dbSet.Find(entity.Id);
            if (existingPerson != null)
            {
                _context.Entry(existingPerson).CurrentValues.SetValues(entity);
            }
        }
    }
}
