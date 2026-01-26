using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(DbContext context) : base(context) { }
    }
}
