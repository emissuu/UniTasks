using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class AdministratorService
    {
        private readonly AdministratorRepository _repo;
        public AdministratorService(AdministratorRepository repo) => _repo = repo;
        public IEnumerable<Data.Models.Administrator> GetAll()
        {
            return _repo.GetAll().ToList();
        }
        public IEnumerable<string> GetAllNames()
        {
            return _repo.GetAllPeople().Select(a => a.Person.Name).ToList();
        }
        public int GetIdByName(string name)
        {
            var admin = _repo.GetAllPeople().FirstOrDefault(a => a.Person.Name == name);
            return admin != null ? admin.Id : -1;
        }
        public void Add(Data.Models.Administrator administratorModel)
        {
            _repo.Add(administratorModel);
            _repo.Save();
        }
        public void Update(Data.Models.Administrator administratorModel)
        {
            _repo.Update(administratorModel);
            _repo.Save();
        }
        public void Delete(int id)
        {
            _repo.Delete(id);
            _repo.Save();
        }
    }
}
