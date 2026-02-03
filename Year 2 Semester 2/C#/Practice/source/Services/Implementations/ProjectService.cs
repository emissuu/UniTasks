using Data.Models;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IAuditLogService _auditLogService;
        public ProjectService(IProjectRepository projectRepository, IAuditLogService auditLogService)
        {
            _projectRepository = projectRepository;
            _auditLogService = auditLogService;
        }
        public IEnumerable<Project> GetAll()
        {
            return _projectRepository.GetAll();
        }

        public Project? GetById(int id)
        {
            return _projectRepository.GetById(id);
        }

        public void Add(Project project)
        {
            _projectRepository.Add(project);
            _projectRepository.Save();
        }

        public void Update(Project project)
        {
            _projectRepository.Update(project);
            _projectRepository.Save();
        }

        public void Delete(int id)
        {
            _projectRepository.Delete(id);
            _projectRepository.Save();
        }
    }
}
