using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class PersonRepository : Repository<Person>
    {
        public PersonRepository(DbContext context) : base(context) { }
    }
}
