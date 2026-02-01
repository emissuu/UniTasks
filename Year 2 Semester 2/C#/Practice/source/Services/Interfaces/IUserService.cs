using Data.Models;
using Services.Models;

namespace Services.Interfaces
{
    public interface IUserService
    {
        public User? LoginUser(string login, string password);
        public (string?, User?) RegisterUser(string login, string password, string email);
        public IEnumerable<UserDetails> GetAllUserDetails();
    }
}
