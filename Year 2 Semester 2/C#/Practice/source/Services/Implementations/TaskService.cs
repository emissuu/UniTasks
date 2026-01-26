using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        // Stuff will be written here shortly
    }
}
