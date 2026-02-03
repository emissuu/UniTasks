using Data.Models;

namespace Services.Interfaces
{
    public interface IProjectService
    {
        public IEnumerable<Project> GetAll();
        public Project? GetById(int id);
        public void Add(Project project);
        public void Update(Project project);
        public void Delete(int id);
    }
}
