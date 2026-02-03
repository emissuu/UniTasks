using Data.Context;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Models = Data.Models;

namespace Repositories.Implementations
{
    public class TaskRepository : Repository<Models.Task>, ITaskRepository
    {
        public TaskRepository(AppDbContext context) : base(context) { }

        public override Models.Task? GetById(int id)
        {
            return _dbSet
                .Include(t => t.Status)
                .Include(t => t.AssignedTo)
                .Include(t => t.Project)
                .FirstOrDefault(t => t.Id == id);
        }

        public override void Update(Models.Task entity)
        {
            var existingEntity = _dbSet.Find(entity.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            }
        }
    }
}
