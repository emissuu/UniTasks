using Data.Models;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User? LoginUser(string login, string password)
        {
            var userByLogin = _userRepository.GetByLogin(login);
            if (userByLogin == null)
                userByLogin = _userRepository.GetByEmail(login);
            if (userByLogin == null || !BCrypt.Net.BCrypt.Verify(password, userByLogin.PasswordHash))
                return null;
            else
                return userByLogin;
        }

        public (string?, User?) RegisterUser(string login, string email, string password)
        {
            if (_userRepository.GetByLogin(login) != null) 
                return ("login", null);
            if (_userRepository.GetByEmail(email) != null)
                return ("email", null);
            try
            {
                _userRepository.Add(new User()
                {
                    RoleId = 1,
                    UserName = login,
                    Email = email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                    CreatedAt = DateTime.UtcNow
                });
                _userRepository.Save();
                return (null, _userRepository.GetByLogin(login));
            }
            catch
            {
                return ("idk", null);
            }
        }
    }
}
