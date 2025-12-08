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
        public IEnumerable<TeamMember> GetAllEventBlocks()
        {
            return _dbSet.Include(tm => tm.EventBlocks).ToList();
        }
        public IEnumerable<TeamMember> GetAllPeople()
        {
            return _dbSet.Include(tm => tm.Person).ToList();
        }
    }
}
