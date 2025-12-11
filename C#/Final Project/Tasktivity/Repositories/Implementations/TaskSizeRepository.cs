using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class TaskSizeRepository : Repository<TaskSize>
    {
        public TaskSizeRepository(DbContext context) : base(context) { }
        public override void Update(TaskSize entity)
        {
            var existingEntity = _dbSet.Find(entity.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            }
        }
    }
}