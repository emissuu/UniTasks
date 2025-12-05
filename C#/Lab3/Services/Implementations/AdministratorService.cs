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
