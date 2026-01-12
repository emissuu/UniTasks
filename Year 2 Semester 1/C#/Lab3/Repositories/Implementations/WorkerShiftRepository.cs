using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class WorkerShiftRepository : Repository<WorkerShift>
    {
        public WorkerShiftRepository(DbContext context) : base(context) { }
        public override void Update(WorkerShift entity)
        {
            var existingPerson = _dbSet.Find(entity.Id);
            if (existingPerson != null)
            {
                _context.Entry(existingPerson).CurrentValues.SetValues(entity);
            }
        }
        public IEnumerable<WorkerShift> GetAllWorkerEventBlock()
        {
            return _dbSet
                .Include(ws => ws.Worker)
                .ThenInclude(w => w.Person)
                .Include(ws => ws.EventBlock)
                .ThenInclude(eb => eb.ZoneActivation)
                .ToList();
        }
    }
}
