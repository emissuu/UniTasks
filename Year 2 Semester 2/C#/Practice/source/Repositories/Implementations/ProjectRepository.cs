using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(AppDbContext context) : base(context) { }

        public override IEnumerable<Project> GetAll()
        {
            return _dbSet
                .Include(p => p.CreatedBy)
                .Include(p => p.Tasks)
                .ThenInclude(t => t.AssignedTo)
                .Include(p => p.Tasks)
                .ThenInclude(t => t.Status)
                .ToList();
        }

        public override Project? GetById(int id)
        {
            return _dbSet
                .Include(p => p.CreatedBy)
                .Include(p => p.Tasks)
                .ThenInclude(t => t.AssignedTo)
                .Include(p => p.Tasks)
                .ThenInclude(t => t.Status)
                .FirstOrDefault(p => p.Id == id);
        }

        public Project? GetByIdSimple(int id)
        {
            return _dbSet
                .FirstOrDefault(p => p.Id == id);
        }

        public override void Update(Project entity)
        {
            var existingEntity = _dbSet.Find(entity.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            }
        }

        public Project? GetByName(string name)
        {
            return _dbSet
                .FirstOrDefault(e => e.Name == name);
        }
    }
}
