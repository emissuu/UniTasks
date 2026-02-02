using Data.Models;
using Services.Models;

namespace Services.Interfaces
{
    public interface IUserService
    {
        public User? GetById(int id);
        public void Update(User user);
        public void Remove(int[] ids);
        public User? LoginUser(string login, string password);
        public bool RegisterUser(User user);
        public (string?, User?) RegisterUser(string login, string password, string email);
        public bool ResetPassword(string login, string passwordOld, string passwordNew);
        public IEnumerable<UserDetails> GetAllUserDetails();
    }
}
