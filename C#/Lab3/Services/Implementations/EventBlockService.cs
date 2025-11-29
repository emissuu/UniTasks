using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class EventBlockService
    {
        private readonly EventBlockRepository _repo;
        public EventBlockService(EventBlockRepository repo) => _repo = repo;
    }
}
