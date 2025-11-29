using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class Incident
    {
        private readonly IncidentRepository _repo;
        public Incident(IncidentRepository repo) => _repo = repo;
    }
}
