using Services.Models;
using Task = Data.Models.Task;

namespace Services.Interfaces
{
    public interface ITaskService
    {
        public Task? GetById(int id);
        public void Add(Task task);
        public void Update(Task task);
        public void Delete(int id);
        public IEnumerable<TaskDetails> GetTaskDetailsByUserId(int id);
    }
}
