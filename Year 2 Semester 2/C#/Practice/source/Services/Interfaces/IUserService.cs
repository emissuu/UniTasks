using Data.Models;
using Services.Models;

namespace Services.Interfaces
{
    public interface IUserService
    {
        public User? GetById(int id);
        public void Update(User user, int userId);
        public void Remove(int[] ids, int userId);
        public User? LoginUser(string login, string password);
        public bool RegisterUser(User user, int userId);
        public (string?, User?) RegisterUser(string login, string password, string email);
        public bool ResetPassword(string login, string passwordOld, string passwordNew, int userId);
        public IEnumerable<UserDetails> GetAllUserDetails();
        public IEnumerable<UserDetails> GetUserDetailsByTeamId(int id);
    }
}
