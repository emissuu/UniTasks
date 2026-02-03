using Data.Models;

namespace Repositories.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        public Project? GetByIdSimple(int id);
        public Project? GetByName(string name);
    }
}
