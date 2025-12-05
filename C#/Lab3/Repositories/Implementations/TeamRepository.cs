using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class TeamRepository : Repository<Team>
    {
        public TeamRepository(DbContext context) : base(context) { }
        public override void Update(Team entity)
        {
            var existingPerson = _dbSet.Find(entity.Id);
            if (existingPerson != null)
            {
                _context.Entry(existingPerson).CurrentValues.SetValues(entity);
            }
        }
    }
}
