using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class TaskSizeService
    {
        private readonly TaskSizeRepository _repo;
        public TaskSizeService(TaskSizeRepository repo) => _repo = repo;
        public IEnumerable<TaskSize> GetAll() => _repo.GetAll();
    }
}