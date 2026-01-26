using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class AuditLogRepository : Repository<AuditLog>
    {
        public AuditLogRepository(DbContext context) : base(context) { }
    }
}
