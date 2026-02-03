using Data.Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System.Text.Json;

namespace Services.Implementations
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IAuditLogRepository _auditlogRepository;
        public AuditLogService(IAuditLogRepository auditlogRepository)
        {
            _auditlogRepository = auditlogRepository;
        }

        public IEnumerable<AuditLog> GetAll()
        {
            return _auditlogRepository.GetAll();
        }

        public void Log(int userId, string entityType, int entityId, string action, object? oldValue, object? newValue)
        {
            string? oldValueSerialized, newValueSerialized;
            if (oldValue != null)
            {
                oldValueSerialized = JsonSerializer.Serialize(oldValue);
            }
            else
            {
                oldValueSerialized = null;
            }
            if (newValue != null)
            {
                newValueSerialized = JsonSerializer.Serialize(newValue);
            }
            else
            {
                newValueSerialized = null;
            }
                _auditlogRepository.Add(new AuditLog()
                {
                    UserId = userId,
                    EntityType = entityType,
                    EntityId = entityId,
                    Action = action,
                    CreatedAt = DateTime.UtcNow,
                    OldValue = oldValueSerialized,
                    NewValue = newValueSerialized
                });
        }
    }
}
