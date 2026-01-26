using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class RoleRepository : Repository<Role>
    {
        public RoleRepository(DbContext context) : base(context) { }
    }
}
