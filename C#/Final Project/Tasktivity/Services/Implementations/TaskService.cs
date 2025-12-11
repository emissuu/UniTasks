using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class TaskService
    {
        private readonly TaskRepository _repo;
        public TaskService(TaskRepository repo) => _repo = repo;
    }
}