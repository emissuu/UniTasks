using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;
        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll() => _dbSet.AsNoTracking().ToList();

        public virtual T? GetById(int id) => _dbSet.Find(id);

        public virtual void Add(T entity) => _dbSet.Add(entity);

        public virtual void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null) _dbSet.Remove(entity);
        }

        public virtual void DeleteAll()
        {
            _dbSet.ExecuteDelete();
        }

        public virtual void Save()
        {
            if (_context.ChangeTracker.HasChanges())
                _context.SaveChanges();
        }
    }
}
