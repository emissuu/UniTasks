using Data.Models;
using Task = Data.Models.Task;
using Repositories.Interfaces;
using Services.Interfaces;
using Services.Models;
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
            string? oldValueSerialized = Serialize(oldValue);
            string? newValueSerialized = Serialize(newValue);
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
            _auditlogRepository.Save();
        }
        private string? Serialize(object? value)
        {
            if (value == null)
                return null;
            if (value is User)
            {
                var user = (User)value;
                return JsonSerializer.Serialize(new UserDto
                    (
                    user.Id,
                    user.RoleId,
                    user.UserName,
                    user.PhoneNumber,
                    user.Email,
                    user.CreatedAt
                    ));
            }
            else if (value is Team)
            {
                var team = (Team)value;
                return JsonSerializer.Serialize(new TeamDto
                    (
                    team.Id,
                    team.CreatedById,
                    team.Name
                    ));
            }
            else if (value is Project)
            {
                var project = (Project)value;
                return JsonSerializer.Serialize(new ProjectDto
                    (
                    project.Id,
                    project.CreatedById,
                    project.TeamId,
                    project.Name,
                    project.Details,
                    project.CreatedAt
                    ));
            }
            else if (value is Task)
            {
                var task = (Task)value;
                return JsonSerializer.Serialize(new TaskDto
                    (
                    task.Id,
                    task.ProjectId,
                    task.CreatedById,
                    task.AssignedToId,
                    task.StatusId,
                    task.Name,
                    task.Details,
                    task.CreatedAt,
                    task.UpdatedAt,
                    task.DueDate
                    ));
            }
            else
            {
                throw new ArgumentException("Unsupported type for serialization");
            }
        }
    }
}
