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
        public IEnumerable<Data.Models.Worker> GetAllPeople()
        {
            return _repo.GetAllPeople();
        }
        public IEnumerable<string> GetAllWorkerNames()
        {
            return _repo.GetAllPeople().Select(w => w.Person.Name).ToList();
        }
        public int GetIdByName(string name)
        {
            var worker = _repo.GetAllPeople().FirstOrDefault(w => w.Person.Name == name);
            return worker != null ? worker.Id : -1;
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
