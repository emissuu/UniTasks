using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class IncidentRepository : Repository<Incident>
    {
        public IncidentRepository(DbContext context) : base(context) { }
    }
}
