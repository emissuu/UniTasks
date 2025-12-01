using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class ZoneService
    {
        private readonly ZoneRepository _repo;
        public ZoneService(ZoneRepository repo) => _repo = repo;
        public IEnumerable<Data.Models.Zone> GetAll()
        {
            return _repo.GetAll().ToList();
        }
        public void Add(Data.Models.Zone zoneModel)
        {
            _repo.Add(zoneModel);
            _repo.Save();
        }
        public void Update(Data.Models.Zone zoneModel)
        {
            _repo.Update(zoneModel);
            _repo.Save();
        }
        public void Delete(int id)
        {
            _repo.Delete(id);
            _repo.Save();
        }
    }
}
