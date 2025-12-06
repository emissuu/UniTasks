using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class IncidentService
    {
        private readonly IncidentRepository _repo;
        public IncidentService(IncidentRepository repo) => _repo = repo;
        public IEnumerable<Data.Models.Incident> GetByEventId(int eventId)
        {
            return _repo.GetAll().Where(i => i.Ticket.EventId == eventId).ToList();
        }
    }
}
