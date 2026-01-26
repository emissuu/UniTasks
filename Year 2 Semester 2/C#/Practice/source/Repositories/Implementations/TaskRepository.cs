using Models = Data.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class TaskRepository : Repository<Models.Task>, ITaskRepository
    {
        public TaskRepository(DbContext context) : base(context) { }
    }
}
