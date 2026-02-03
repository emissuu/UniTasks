using Task = Data.Models.Task;

namespace Repositories.Interfaces
{
    public interface ITaskRepository : IRepository<Task>
    {
        public Task? GetByIdSimple(int id);
        public Task? GetByName(string name);
    }
}
