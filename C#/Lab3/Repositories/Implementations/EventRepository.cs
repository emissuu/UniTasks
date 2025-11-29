using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class EventRepository : Repository<Event>
    {
        public EventRepository(DbContext context) : base(context) { }
    }
}
