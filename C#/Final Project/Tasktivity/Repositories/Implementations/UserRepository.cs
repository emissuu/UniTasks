using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(DbContext context) : base(context) { }
        public User Get()
        {
            return _dbSet.Include(u => u.ActiveTheme).ToList()[0];
        }
        public override void Update(User entity)
        {
            var existingEntity = _dbSet.Find(entity.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            }
        }
    }
}