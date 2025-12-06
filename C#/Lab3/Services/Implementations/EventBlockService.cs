using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class EventBlockService
    {
        private readonly EventBlockRepository _repo;
        public EventBlockService(EventBlockRepository repo) => _repo = repo;
        public IEnumerable<Data.Models.EventBlock> GetByEventId(int eventId)
        {
            return _repo.GetAllZoneActivation().Where(eb => eb.ZoneActivation.EventId == eventId).ToList();
        }
        public void Add(Data.Models.EventBlock eventBlock)
        {
            _repo.Add(eventBlock);
            _repo.Save();
        }
        public void Update(Data.Models.EventBlock eventBlock)
        {
            _repo.Update(eventBlock);
            _repo.Save();
        }
        public void Delete(int eventId)
        {
            _repo.Delete(eventId);
            _repo.Save();
        }
    }
}
