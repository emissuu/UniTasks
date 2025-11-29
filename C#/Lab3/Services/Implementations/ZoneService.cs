using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class ZoneService
    {
        private readonly ZoneRepository _repo;
        public ZoneService(ZoneRepository repo) => _repo = repo;
    }
}
