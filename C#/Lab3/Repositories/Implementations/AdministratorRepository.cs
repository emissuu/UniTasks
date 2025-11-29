using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class AdministratorRepository : Repository<Administrator>
    {
        public AdministratorRepository(DbContext context) : base(context) { }
    }
}
