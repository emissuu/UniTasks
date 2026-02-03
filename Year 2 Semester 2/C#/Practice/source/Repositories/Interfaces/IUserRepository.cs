using Data.Models;

namespace Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public User? GetByIdSimple(int id);
        public User? GetByLogin(string login);
        public User? GetByEmail(string email);
        public User? GetByName(string name);
    }
}
