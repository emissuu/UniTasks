using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class ThemeService
    {
        private readonly ThemeRepository _repo;
        public ThemeService(ThemeRepository repo) => _repo = repo;
    }
}