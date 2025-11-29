using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class WorkerShiftService
    {
        private readonly WorkerShiftRepository _repo;
        public WorkerShiftService(WorkerShiftRepository repo) => _repo = repo;
    }
}
