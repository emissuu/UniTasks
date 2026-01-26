using Models = Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class TaskRepository : Repository<Models.Task>
    {
        public TaskRepository(DbContext context) : base(context) { }
    }
}
