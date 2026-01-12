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
        public IEnumerable<string> GetAllNames()
        {
            return _repo.GetAll().Select(z => z.Name).ToList();
        }
        public int GetIdByName(string name)
        {
            var admin = _repo.GetAll().FirstOrDefault(z => z.Name == name);
            return admin != null ? admin.Id : -1;
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
