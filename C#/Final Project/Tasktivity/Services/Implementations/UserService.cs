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
        public User GetUser() => _repo.Get();
        public int[] GetExperience()
        {
            int exp = _repo.Get().TotalExperience;
            Func<int, double> formula = lvl => 11 + 4 * Math.Sqrt(lvl);
            int lvl = 0, total = 0;
            while (true)
            {
                int expLoss = (int)Math.Floor(formula(lvl + 1));
                if (exp - expLoss >= 0)
                {
                    exp -= expLoss;
                    lvl++;
                }
                else
                {
                    total = expLoss;
                    break;
                }
            }
            return [lvl, exp, total];
        }
    }
}