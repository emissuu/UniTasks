using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Task = Data.Models.Task;

namespace Repositories.Implementations
{
    public class TaskRepository : Repository<Task>, ITaskRepository
    {
        public TaskRepository(AppDbContext context) : base(context) { }

        public override IEnumerable<Task> GetAll()
        {
            return _dbSet
                .Include(t => t.CreatedBy)
                .ToList();
        }

        public override Task? GetById(int id)
        {
            return _dbSet
                .Include(t => t.Status)
                .Include(t => t.AssignedTo)
                .Include(t => t.Project)
                .FirstOrDefault(t => t.Id == id);
        }

        public Task? GetByIdSimple(int id)
        {
            return _dbSet
                .FirstOrDefault(t => t.Id == id);
        }

        public override void Add(Task task)
        {
            _dbSet.Add(task);
        }

        public override void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null) _dbSet.Remove(entity);
        }

        public override void Update(Task entity)
        {
            var existingEntity = _dbSet.Find(entity.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            }
        }

        public Task? GetByName(string name)
        {
            return _dbSet
                .FirstOrDefault(e => e.Name == name);
        }
    }
}
