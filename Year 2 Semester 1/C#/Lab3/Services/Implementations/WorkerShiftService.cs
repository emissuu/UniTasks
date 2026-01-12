using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class WorkerShiftService
    {
        private readonly WorkerShiftRepository _repo;
        public WorkerShiftService(WorkerShiftRepository repo) => _repo = repo;
        public IEnumerable<Data.Models.WorkerShift> GetByEventId(int eventId)
        {
            return _repo.GetAllWorkerEventBlock().Where(ws => ws.EventBlock.ZoneActivation.EventId == eventId).ToList();
        }
        public void Add(Data.Models.WorkerShift workerShift)
        {
            _repo.Add(workerShift);
            _repo.Save();
        }
        public void Update(Data.Models.WorkerShift workerShift)
        {
            _repo.Update(workerShift);
            _repo.Save();
        }
        public void Delete(int id)
        {
            _repo.Delete(id);
            _repo.Save();
        }
    }
}
