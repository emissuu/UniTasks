using Services.Models;
using Task = Data.Models.Task;

namespace Services.Interfaces
{
    public interface ITaskService
    {
        public Task? GetById(int id);
        public void Add(Task task, int userId);
        public void Update(Task task, int userId);
        public void Delete(int id, int userId);
        public IEnumerable<TaskDetails> GetTaskDetailsByUserId(int id);
    }
}
