using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class ZoneActivationRepository : Repository<ZoneActivation>
    {
        public ZoneActivationRepository(DbContext context) : base(context) { }
    }
}
