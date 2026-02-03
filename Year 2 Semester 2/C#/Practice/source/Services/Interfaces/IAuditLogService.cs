using Data.Models;

namespace Services.Interfaces
{
    public interface IAuditLogService
    {
        public IEnumerable<AuditLog> GetAll();
        public void Log(int userId, string entityType, int entityId, string action, object? oldValue, object? newValue);
    }
}
