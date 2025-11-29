using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class TicketService
    {
        private readonly TicketRepository _repo;
        public TicketService(TicketRepository repo) => _repo = repo;
    }
}
