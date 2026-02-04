using Data.Models;

namespace Services.Models
{
    public class AuditLogDetails
    {
        public AuditLog AuditLog { get; set; }
        public int Id { get { return AuditLog.Id; } }
        public User User {get { return AuditLog.User; } }
        public string EntityType { get { return AuditLog.EntityType; } }
        public int EntityId { get { return AuditLog.EntityId; } }
        public string Action { get { return AuditLog.Action; } }
        public DateTime CreatedAt { get { return AuditLog.CreatedAt; } }
        public object? OldValue { get { return AuditLog.OldValue; } }
        public object? NewValue { get { return AuditLog.NewValue; } }
        
        public AuditLogDetails(AuditLog auditLog)
        {
            AuditLog = auditLog;
        }

        public string GetCreatedAt
        {
            get
            {
                return CreatedAt.ToLocalTime().ToString("g");
            }
        }
        public string GetCreatedAtUtc
        {
            get
            {
                return CreatedAt.ToString("g");
            }
        }
    }
}
