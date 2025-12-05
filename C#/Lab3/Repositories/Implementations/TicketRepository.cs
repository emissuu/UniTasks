using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class TicketRepository : Repository<Ticket>
    {
        public TicketRepository(DbContext context) : base(context) { }
        public override void Update(Ticket entity)
        {
            var existingPerson = _dbSet.Find(entity.Id);
            if (existingPerson != null)
            {
                _context.Entry(existingPerson).CurrentValues.SetValues(entity);
            }
        }
    }
}
