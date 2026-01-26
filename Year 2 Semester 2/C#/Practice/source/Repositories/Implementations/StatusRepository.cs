using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class StatusRepository : Repository<Status>, IStatusRepository
    {
        public StatusRepository(DbContext context) : base(context) { }
    }
}
