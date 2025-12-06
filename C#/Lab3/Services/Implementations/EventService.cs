using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class EventService
    {
        private readonly EventRepository _repo;
        public EventService(EventRepository repo) => _repo = repo;
        public IEnumerable<Data.Models.Event> GetAll()
        {
            return _repo.GetAll().ToList();
        }
        public IEnumerable<Data.Models.Event> GetAllEventsInAWeek()
        {
            return _repo.GetAll().Where(e => e.Date >= DateTime.Now.AddDays(-1) && e.Date <= DateTime.Now.AddDays(6)).ToList();
        }
        public Data.Models.Event GetById(int id)
        {
            return _repo.GetById(id);
        }
        public void Add(Data.Models.Event eventModel)
        {
            _repo.Add(eventModel);
            _repo.Save();
        }
        public void Update(Data.Models.Event eventModel)
        {
            _repo.Update(eventModel);
            _repo.Save();
        }
        public void Delete(int id)
        {
            _repo.Delete(id);
            _repo.Save();
        }
    }
}
