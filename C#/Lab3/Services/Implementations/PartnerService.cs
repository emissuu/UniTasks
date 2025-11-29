using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class PartnerService
    {
        private readonly PartnerRepository _repo;
        public PartnerService(PartnerRepository repo) => _repo = repo;
    }
}
