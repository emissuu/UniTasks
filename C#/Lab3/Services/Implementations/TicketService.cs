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
        public IEnumerable<string> GetAllNamesByEventId(int eventId)
        {
            return _repo.GetAll().Where(t => t.EventId == eventId).Select(tt => tt.QrCode).ToList();
        }
        public int GetIdByQrCode(string qrCode)
        {
            var ticket = _repo.GetAll().FirstOrDefault(t => t.QrCode == qrCode);
            return ticket != null ? ticket.Id : -1;
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
