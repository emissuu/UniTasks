using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;
        public StatusService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }
        // Stuff will be written here shortly
    }
}
