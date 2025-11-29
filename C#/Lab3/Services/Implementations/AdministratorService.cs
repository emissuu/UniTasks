using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class AdministratorService
    {
        private readonly AdministratorRepository _repo;
        public AdministratorService(AdministratorRepository repo) => _repo = repo;
    }
}
