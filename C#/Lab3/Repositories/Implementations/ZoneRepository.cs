using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class ZoneRepository : Repository<Zone>
    {
        public ZoneRepository(DbContext context) : base(context) { }
        public override void Update(Zone entity)
        {
            var existingPerson = _dbSet.Find(entity.Id);
            if (existingPerson != null)
            {
                _context.Entry(existingPerson).CurrentValues.SetValues(entity);
            }
        }
    }
}
