using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class EventBlockRepository : Repository<EventBlock>
    {
        public EventBlockRepository(DbContext context) : base(context) { }
    }
}
