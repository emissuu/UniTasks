using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class TicketService
    {
        private readonly TicketRepository _repo;
        public TicketService(TicketRepository repo) => _repo = repo;
        public IEnumerable<Data.Models.Ticket> GetAll()
        {
            return _repo.GetAll().ToList();
        }
        public void Add(Data.Models.Ticket ticket)
        {
            _repo.Add(ticket);
            _repo.Save();
        }
        public void Update(Data.Models.Ticket ticket)
        {
            _repo.Update(ticket);
            _repo.Save();
        }
        public void Delete(int id)
        {
            _repo.Delete(id);
            _repo.Save();
        }
    }
}
