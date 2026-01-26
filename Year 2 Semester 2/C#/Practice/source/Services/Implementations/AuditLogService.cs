using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IAuditLogRepository _auditlogRepository;
        public AuditLogService(IAuditLogRepository auditlogRepository)
        {
            _auditlogRepository = auditlogRepository;
        }
        // Stuff will be written here shortly
    }
}
