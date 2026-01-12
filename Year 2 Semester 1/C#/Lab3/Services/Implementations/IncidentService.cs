using Data.Models;
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
            return _repo.GetAllTickets().Where(i => i.Ticket.EventId == eventId).ToList();
        }
        public void Add(Incident incident)
        {
            _repo.Add(incident);
            _repo.Save();
        }
        public void Update(Incident incident)
        {
            _repo.Update(incident);
            _repo.Save();
        }
        public void Delete(int incidentId)
        {
            _repo.Delete(incidentId);
            _repo.Save();
        }
    }
}
