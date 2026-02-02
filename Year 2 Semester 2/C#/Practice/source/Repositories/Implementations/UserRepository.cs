using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public override IEnumerable<User> GetAll()
        {
            return _dbSet
                .Include(u => u.Role)
                .ToList();
        }

        public override User? GetById(int id)
        {
            return _dbSet
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Id == id);
        }

        public override void Update(User entity)
        {
            var existingEntity = _dbSet.Find(entity.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            }
        }

        public User? GetByLogin(string login)
        {
            return _dbSet
                .Include(u => u.Role)
                .FirstOrDefault(u => u.UserName == login);
        }

        public User? GetByEmail(string email)
        {
            return _dbSet
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Email == email);
        }
    }
}
