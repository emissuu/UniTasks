using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;
using Services.Models;

namespace Services.Implementations
{
    public class TaskService
    {
        private readonly TaskRepository _repo;
        public TaskService(TaskRepository repo) => _repo = repo;
        public IEnumerable<Data.Models.Task> GetAllSizes()
        {
            return _repo.GetAllSizes().ToList();
        }
        public IEnumerable<TaskPriority> GetAllTaskPriorities()
        {
            //return _repo.GetAllSizesCategories().ToList();
            var tasks = _repo.GetAllSizesCategories().ToList();
            List<TaskPriority> taskPriorities = new();
            foreach (var task in tasks)
            {
                TaskPriority priority = new()
                {
                    Id = task.Id,
                    Name = task.Name,
                    Notes = task.Notes,
                    Size = task.Size,
                    Category = task.Category,
                    WhenTo = task.WhenTo,
                    CompletedAt = task.CompletedAt
                };
                taskPriorities.Add(priority);
            }
            return taskPriorities;
        }
    }
}