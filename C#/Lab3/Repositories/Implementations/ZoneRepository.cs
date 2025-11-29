using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class ZoneRepository : Repository<Zone>
    {
        public ZoneRepository(DbContext context) : base(context) { }
    }
}
