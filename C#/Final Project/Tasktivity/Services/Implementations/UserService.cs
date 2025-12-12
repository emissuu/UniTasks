using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;
using Services.Models;

namespace Services.Implementations
{
    public class UserService
    {
        private readonly UserRepository _repo;
        public UserService(UserRepository repo) => _repo = repo;
        public ThemeColors GetCurrentTheme()
        {
            return new ThemeColors(_repo.Get().ActiveTheme);
        }
    }
}