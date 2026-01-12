using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class ZoneActivationService
    {
        private readonly ZoneActivationRepository _repo;
        public ZoneActivationService(ZoneActivationRepository repo) => _repo = repo;
        public IEnumerable<Data.Models.ZoneActivation> GetByEventId(int eventId)
        {
            return _repo.GetAllZonePartner().Where(za => za.EventId == eventId).ToList();
        }
        public IEnumerable<string> GetAllNamesByEventId(int eventId)
        {
            return _repo.GetAllZonePartner()
                        .Where(za => za.EventId == eventId)
                        .Select(za => za.Zone.Name)
                        .ToList();
        }
        public int GetIdByNameAndEventId(string zoneName, int eventId)
        {
            var zoneActivation = _repo.GetAllZonePartner()
                                     .FirstOrDefault(za => za.Zone.Name == zoneName && za.EventId == eventId);
            return zoneActivation != null ? zoneActivation.Id : -1;
        }
        public void Add(Data.Models.ZoneActivation zoneActivation)
        {
            _repo.Add(zoneActivation);
            _repo.Save();
        }
        public void Update(Data.Models.ZoneActivation zoneActivation)
        {
            _repo.Update(zoneActivation);
            _repo.Save();
        }
        public void Delete(int zoneId)
        {
            _repo.Delete(zoneId);
            _repo.Save();
        }
    }
}
