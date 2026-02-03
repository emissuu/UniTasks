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

        public void Add(Project project, int userId)
        {
            _projectRepository.Add(project);
            _projectRepository.Save();
            var newValue = _projectRepository.GetByName(project.Name);
            _auditLogService.Log(userId, "Project", newValue.Id, "CREATE", null, newValue);
        }

        public void Update(Project project, int userId)
        {
            var oldValue = _projectRepository.GetByIdSimple(project.Id);
            _projectRepository.Update(project);
            _projectRepository.Save();
            var newValue = _projectRepository.GetByIdSimple(project.Id);
            _auditLogService.Log(userId, "Project", newValue.Id, "UPDATE", oldValue, newValue);
        }

        public void Delete(int id, int userId)
        {
            var oldValue = _projectRepository.GetByIdSimple(id);
            _projectRepository.Delete(id);
            _projectRepository.Save();
            _auditLogService.Log(userId, "Project", id, "REMOVE", oldValue, null);
        }
    }
}
