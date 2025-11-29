using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class TicketRepository : Repository<Ticket>
    {
        public TicketRepository(DbContext context) : base(context) { }
    }
}
