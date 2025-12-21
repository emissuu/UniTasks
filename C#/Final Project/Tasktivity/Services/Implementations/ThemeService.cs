using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;
using Services.Models;

namespace Services.Implementations
{
    public class ThemeService
    {
        private readonly ThemeRepository _repo;
        public ThemeService(ThemeRepository repo) => _repo = repo;
        public IEnumerable<ThemeColors> GetAllThemeColors()
        {
            return _repo.GetAll().Select(t => new ThemeColors(t)).ToList();
        }
    }
}