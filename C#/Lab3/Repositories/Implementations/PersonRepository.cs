using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class PersonRepository : Repository<Person>
    {
        public PersonRepository(DbContext context) : base(context) { }
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
