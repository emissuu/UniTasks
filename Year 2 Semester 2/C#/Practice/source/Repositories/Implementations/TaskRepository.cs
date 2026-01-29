using Data.Context;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Models = Data.Models;

namespace Repositories.Implementations
{
    public class TaskRepository : Repository<Models.Task>, ITaskRepository
    {
        public TaskRepository(AppDbContext context) : base(context) { }
    }
}
