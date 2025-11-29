using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class WorkerRepository : Repository<Worker>
    {
        public WorkerRepository(DbContext context) : base(context) { }
    }
}
