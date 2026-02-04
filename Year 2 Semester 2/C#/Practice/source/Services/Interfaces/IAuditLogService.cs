using Data.Models;
using Services.Models;

namespace Services.Interfaces
{
    public interface IAuditLogService
    {
        public IEnumerable<AuditLog> GetAll();
        public IEnumerable<AuditLogDetails> GetAllAuditDetails();
        public void Log(int userId, string entityType, int entityId, string action, object? oldValue, object? newValue);
    }
}
