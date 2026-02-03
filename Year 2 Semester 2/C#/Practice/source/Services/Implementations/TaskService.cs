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

        public void Add(Task task)
        {
            _taskRepository.Add(task);
            _taskRepository.Save();
        }

        public void Update(Task task)
        {
            _taskRepository.Update(task);
            _taskRepository.Save();
        }

        public void Delete(int id)
        {
            _taskRepository.Delete(id);
            _taskRepository.Save();
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
