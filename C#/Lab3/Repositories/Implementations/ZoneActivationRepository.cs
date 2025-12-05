using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class ZoneActivationRepository : Repository<ZoneActivation>
    {
        public ZoneActivationRepository(DbContext context) : base(context) { }
        public override void Update(ZoneActivation entity)
        {
            var existingPerson = _dbSet.Find(entity.Id);
            if (existingPerson != null)
            {
                _context.Entry(existingPerson).CurrentValues.SetValues(entity);
            }
        }
    }
}
