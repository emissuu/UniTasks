using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class WorkerService
    {
        private readonly WorkerRepository _repo;
        public WorkerService(WorkerRepository repo) => _repo = repo;
    }
}
