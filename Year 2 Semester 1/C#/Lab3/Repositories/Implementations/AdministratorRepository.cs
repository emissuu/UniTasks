using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class AdministratorRepository : Repository<Administrator>
    {
        public AdministratorRepository(DbContext context) : base(context) { }
        public override void Update(Administrator entity)
        {
            var existingPerson = _dbSet.Find(entity.Id);
            if (existingPerson != null)
            {
                _context.Entry(existingPerson).CurrentValues.SetValues(entity);
            }
        }
        public IEnumerable<Administrator> GetAllPeople()
        {
            return _dbSet.Include(a => a.Person).AsNoTracking().ToList();
        }
    }
}
