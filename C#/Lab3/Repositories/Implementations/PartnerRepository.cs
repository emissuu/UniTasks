using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class PartnerRepository : Repository<Partner>
    {
        public PartnerRepository(DbContext context) : base(context) { }
    }
}
