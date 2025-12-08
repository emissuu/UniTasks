using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class EventBlockRepository : Repository<EventBlock>
    {
        public EventBlockRepository(DbContext context) : base(context) { }
        public override void Update(EventBlock entity)
        {
            // write so that TeamMembers are updated correctly
            var existingEventBlock = _dbSet.Include(eb => eb.TeamMembers)
                                          .FirstOrDefault(eb => eb.Id == entity.Id);
            if (existingEventBlock != null)
                {
                _context.Entry(existingEventBlock).CurrentValues.SetValues(entity);
                existingEventBlock.TeamMembers.Clear();
                foreach (var teamMember in entity.TeamMembers)
                {
                    existingEventBlock.TeamMembers.Add(teamMember);
                }
            }
        }
        public IEnumerable<EventBlock> GetAllZoneActivation()
        {
            return _dbSet.Include(eb => eb.ZoneActivation)
                .ThenInclude(za => za.Zone)
                .AsNoTracking().ToList();
        }
    }
}
