using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class PartnerService
    {
        private readonly PartnerRepository _repo;
        public PartnerService(PartnerRepository repo) => _repo = repo;
        public IEnumerable<Data.Models.Partner> GetAll()
        {
            return _repo.GetAll().ToList();
        }
        public IEnumerable<string> GetAllNames()
        {
            return _repo.GetAll().Select(p => p.Name).ToList();
        }
        public int GetIdByName(string name)
        {
            var partner = _repo.GetAll().FirstOrDefault(p => p.Name == name);
            return partner != null ? partner.Id : -1;
        }
        public Data.Models.Partner GetById(int id)
        {
            return _repo.GetById(id);
        }
        public void Add(Data.Models.Partner partnerModel)
        {
            _repo.Add(partnerModel);
            _repo.Save();
        }
        public void Update(Data.Models.Partner partnerModel)
        {
            _repo.Update(partnerModel);
            _repo.Save();
        }
        public void Delete(int id)
        {
            _repo.Delete(id);
            _repo.Save();
        }
    }
}
