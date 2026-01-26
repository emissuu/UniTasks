using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        // Stuff will be written here shortly
    }
}
