using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class WorkerService
    {
        private readonly WorkerRepository _repo;
        public WorkerService(WorkerRepository repo) => _repo = repo;
        public IEnumerable<Data.Models.Worker> GetAll()
        {
            return _repo.GetAll().ToList();
        }
        public void Add(Data.Models.Worker workerModel)
        {
            _repo.Add(workerModel);
            _repo.Save();
        }
        public void Update(Data.Models.Worker workerModel)
        {
            _repo.Update(workerModel);
            _repo.Save();
        }
        public void Delete(int id)
        {
            _repo.Delete(id);
            _repo.Save();
        }
    }
}
