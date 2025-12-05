using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class IncidentRepository : Repository<Incident>
    {
        public IncidentRepository(DbContext context) : base(context) { }
        public override void Update(Incident entity)
        {
            var existingPerson = _dbSet.Find(entity.Id);
            if (existingPerson != null)
            {
                _context.Entry(existingPerson).CurrentValues.SetValues(entity);
            }
        }
    }
}
