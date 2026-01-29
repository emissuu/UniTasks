using Data.Models;

namespace Services.Interfaces
{
    public interface IUserService
    {
        public User? LoginUser(string login, string password);
        public (string?, User?) RegisterUser(string login, string password, string email);
    }
}
