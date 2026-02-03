using Data.Models;
using Repositories.Interfaces;
using Services.Interfaces;
using Services.Models;

namespace Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuditLogService _auditLogService;
        public UserService(IUserRepository userRepository, IAuditLogService auditLogService)
        {
            _userRepository = userRepository;
            _auditLogService = auditLogService;
        }

        public User? GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
            _userRepository.Save();
        }

        public void Remove(int[] ids)
        {
            foreach (int id in ids)
            {
                _userRepository.Delete(id);
            }
            _userRepository.Save();
        }

        public User? LoginUser(string login, string password)
        {
            var userByLogin = _userRepository.GetByLogin(login);
            if (userByLogin == null)
                userByLogin = _userRepository.GetByEmail(login);
            if (!BCrypt.Net.BCrypt.Verify(password, userByLogin.PasswordHash))
                return null;
            else
                return userByLogin;
        }

        public bool RegisterUser(User user)
        {
            if (_userRepository.GetByLogin(user.UserName) != null)
                return false;
            try
            {
                _userRepository.Add(new User()
                {
                    RoleId = user.RoleId,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash),
                    CreatedAt = DateTime.UtcNow
                });
                _userRepository.Save();
                return true;
            }
            catch
            {
                return false;
            }
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

        public bool ResetPassword(string login, string passwordOld, string passwordNew)
        {
            var userByLogin = _userRepository.GetByLogin(login);
            if (!BCrypt.Net.BCrypt.Verify(passwordOld, userByLogin.PasswordHash))
                return false;
            userByLogin.PasswordHash = BCrypt.Net.BCrypt.HashPassword(passwordNew);
            _userRepository.Update(userByLogin);
            _userRepository.Save();
            return true;
        }

        public IEnumerable<UserDetails> GetAllUserDetails()
        {
            return _userRepository.GetAll()
                .Select(u => new UserDetails(
                    u.Id,
                    u.UserName,
                    u.Email,
                    u.PhoneNumber,
                    u.Role,
                    u.CreatedAt
                ));
        }

        public IEnumerable<UserDetails> GetUserDetailsByTeamId(int id)
        {
            return _userRepository.GetAll()
                .Where(u => u.TeamUsers.Any(tu => tu.TeamId == id))
                .Select(u => new UserDetails(
                    u.Id,
                    u.UserName,
                    u.Email,
                    u.PhoneNumber,
                    u.Role,
                    u.CreatedAt
                )).ToList();
        }
    }
}
