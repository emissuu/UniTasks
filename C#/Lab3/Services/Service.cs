using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class TemplateService
    {
        private readonly TemplateRepository _repo;
        public TemplateService(TemplateRepository repo) => _repo = repo;
    }
}
