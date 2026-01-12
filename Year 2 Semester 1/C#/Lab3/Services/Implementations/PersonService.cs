using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;
using Services.Models;

namespace Services.Implementations
{
    public class PersonService
    {
        private readonly PersonRepository _repo;
        public PersonService(PersonRepository repo) => _repo = repo;
        public IEnumerable<Data.Models.Person> GetAll()
        {
            return _repo.GetAll().ToList();
        }
        public Data.Models.Person GetById(int id)
        {
            return _repo.GetById(id);
        }
        public void Add(Data.Models.Person personModel)
        {
            _repo.Add(personModel);
            _repo.Save();
        }
        public void Update(Data.Models.Person personModel)
        {
            _repo.Update(personModel);
            _repo.Save();
        }
        public void Delete(int id)
        {
            _repo.Delete(id);
            _repo.Save();
        }
        public IEnumerable<Models.PersonRole> GetAllPersonRole()
        {
            var Person = _repo.GetAllPersonRole().ToList();
            List<Models.PersonRole> personRoles = new();
            foreach (var role in Person)
            {
                Models.PersonRole personRole = new()
                {
                    Id = role.Id,
                    Name = role.Name,
                    ContactNumber = role.ContactNumber,
                    Administrator = role.Administrator,
                    Worker = role.Worker,
                    Guest = role.TeamMember
                };
                personRoles.Add(personRole);
            }
            return personRoles;
        }
        public IEnumerable<PersonTicket> GetAllPersonTicketByEventId(int eventId)
        {
            var tickets = _repo.GetAllTicket().ToList();
            List<PersonTicket> personTickets = new();
            foreach (var ticket in tickets)
            {
                PersonTicket personTicket = new()
                {
                    Id = ticket.Tickets?.FirstOrDefault(t => t.EventId == eventId)?.Id ?? null,
                    PersonId = ticket.Id,
                    Name = ticket.Name,
                    ContactNumber = ticket.ContactNumber,
                    QrCode = ticket.Tickets?.FirstOrDefault(t => t.EventId == eventId)?.QrCode ?? null
                };
                personTickets.Add(personTicket);
            }
            return personTickets;
        }
    }
}
