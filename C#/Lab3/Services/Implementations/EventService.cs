using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class EventService
    {
        private readonly EventRepository _repo;
        public EventService(EventRepository repo) => _repo = repo;
    }
}
