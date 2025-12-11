using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class TaskRepository : Repository<Data.Models.Task>
    {
        public TaskRepository(DbContext context) : base(context) { }
        public override void Update(Data.Models.Task entity)
        {
            var existingEntity = _dbSet.Find(entity.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            }
        }
    }
}