using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class ProjectRepository : Repository<Project>
    {
        public ProjectRepository(DbContext context) : base(context) { }
    }
}
