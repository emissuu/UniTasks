using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class StatusRepository : Repository<Status>
    {
        public StatusRepository(DbContext context) : base(context) { }
    }
}
