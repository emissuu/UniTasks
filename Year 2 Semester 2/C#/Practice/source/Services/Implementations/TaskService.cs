using Repositories.Interfaces;
using Task = Data.Models.Task;
using Services.Interfaces;
using Services.Models;

namespace Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IAuditLogService _auditLogService;
        public TaskService(ITaskRepository taskRepository, IAuditLogService auditLogService)
        {
            _taskRepository = taskRepository;
            _auditLogService = auditLogService;
        }

        public Task? GetById(int id)
        {
            return _taskRepository.GetById(id);
        }

        public void Add(Task task, int userId)
        {
            _taskRepository.Add(task);
            _taskRepository.Save();
            var newValue = _taskRepository.GetByName(task.Name);
            _auditLogService.Log(userId, "Task", newValue.Id, "CREATE", null, newValue);
        }

        public void Update(Task task, int userId)
        {
            var oldValue = _taskRepository.GetByIdSimple(task.Id);
            _taskRepository.Update(task);
            _taskRepository.Save();
            var newValue = _taskRepository.GetByIdSimple(task.Id);
            _auditLogService.Log(userId, "Task", newValue.Id, "UPDATE", oldValue, newValue);
        }

        public void Delete(int id, int userId)
        {
            var oldValue = _taskRepository.GetByIdSimple(id);
            _taskRepository.Delete(id);
            _taskRepository.Save();
            _auditLogService.Log(userId, "Task", id, "REMOVE", oldValue, null);
        }

        public IEnumerable<TaskDetails> GetTaskDetailsByUserId(int id)
        {
            return _taskRepository.GetAll()
                .Where(t => t.AssignedToId == id)
                .Select(t => new TaskDetails() { task = t})
                .ToList();
        }
    }
}
