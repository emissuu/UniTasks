using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class WorkerShiftRepository : Repository<WorkerShift>
    {
        public WorkerShiftRepository(DbContext context) : base(context) { }
    }
}
