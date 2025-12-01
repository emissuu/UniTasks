using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class IncidentService
    {
        private readonly IncidentRepository _repo;
        public IncidentService(IncidentRepository repo) => _repo = repo;
    }
}
