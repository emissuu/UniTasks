using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class PersonService
    {
        private readonly PersonRepository _repo;
        public PersonService(PersonRepository repo) => _repo = repo;
    }
}
