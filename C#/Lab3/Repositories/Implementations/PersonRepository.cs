using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class PersonRepository : Repository<Person>
    {
        public PersonRepository(DbContext context) : base(context) { }
        public override void Update(Person entity)
        {
            var existingPerson = _dbSet.Find(entity.Id);
            if (existingPerson != null)
            {
                _context.Entry(existingPerson).CurrentValues.SetValues(entity);
            }
        }
        public IEnumerable<Person> GetAllPersonRole()
        {
            return _context.Set<Person>()
                .Include(p => p.Administrator)
                .Include(p => p.Worker)
                .Include(p => p.TeamMember)
                .ToList();
        }
    }
}
