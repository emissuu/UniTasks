using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class EventBlockRepository : Repository<EventBlock>
    {
        public EventBlockRepository(DbContext context) : base(context) { }
        public override void Update(EventBlock entity)
        {
            var existingPerson = _dbSet.Find(entity.Id);
            if (existingPerson != null)
            {
                _context.Entry(existingPerson).CurrentValues.SetValues(entity);
            }
        }
    }
}
