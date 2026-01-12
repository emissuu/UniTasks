using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(DbContext context) : base(context) { }
        public override void Update(Category entity)
        {
            var existingEntity = _dbSet.Find(entity.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            }
        }
    }
}