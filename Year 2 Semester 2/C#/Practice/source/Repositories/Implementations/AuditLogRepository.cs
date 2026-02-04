using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class AuditLogRepository : Repository<AuditLog>, IAuditLogRepository
    {
        public AuditLogRepository(AppDbContext context) : base(context) { }

        public override IEnumerable<AuditLog> GetAll()
        {
            return _dbSet
                .Include(a => a.User)
                .ToList();
        }
    }
}
