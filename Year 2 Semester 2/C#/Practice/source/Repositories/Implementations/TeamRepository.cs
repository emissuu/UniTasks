using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(AppDbContext context) : base(context) { }

        public override IEnumerable<Team> GetAll()
        {
            return _dbSet
                .Include(t => t.TeamUsers)
                .ThenInclude(tu => tu.User)
                .ThenInclude(u => u.Role)
                .Include(t => t.CreatedBy)
                .ToList();
        }

        public override Team? GetById(int id)
        {
            return _dbSet
                .Include(t => t.TeamUsers)
                .ThenInclude(tu => tu.User)
                .ThenInclude(u => u.Role)
                .Include(t => t.CreatedBy)
                .FirstOrDefault(t => t.Id == id);
        }

        public Team? GetByIdSimple(int id)
        {
            return _dbSet
                .FirstOrDefault(t => t.Id == id);
        }

        public override void Update(Team entity)
        {
            var existingEntity = _dbSet.Find(entity.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            }
        }

        public Team? GetByName(string name)
        {
            return _dbSet
                .FirstOrDefault(e => e.Name == name);
        }

        public void AddTeamUser(TeamUser teamUser)
        {
            _context.Add<TeamUser>(teamUser);
        }
    }
}
