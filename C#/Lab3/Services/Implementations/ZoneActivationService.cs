using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class ZoneActivationService
    {
        private readonly ZoneActivationRepository _repo;
        public ZoneActivationService(ZoneActivationRepository repo) => _repo = repo;
    }
}
