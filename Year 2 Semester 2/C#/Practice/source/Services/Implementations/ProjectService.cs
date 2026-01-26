using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        // Stuff will be written here shortly
    }
}
