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

        public void Update(User user, int userId)
        {
            var oldUser = _userRepository.GetByIdSimple(user.Id);
            _userRepository.Update(user);
            _userRepository.Save();
            var newUser = _userRepository.GetByIdSimple(userId);
            _auditLogService.Log(userId, "User", user.Id, "UPDATE", oldUser, newUser);
        }

        public void Remove(int[] ids, int userId)
        {
            foreach (int id in ids)
            {
                var oldUser = _userRepository.GetByIdSimple(id);
                _userRepository.Delete(id);
                _auditLogService.Log(userId, "User", id, "REMOVE", oldUser, null);
            }
            _userRepository.Save();
        }

        public User? LoginUser(string login, string password)
        {
            var userByLogin = _userRepository.GetByLogin(login);
            if (userByLogin == null)
                userByLogin = _userRepository.GetByEmail(login);
            if (userByLogin == null)
                return null;
            if (!BCrypt.Net.BCrypt.Verify(password, userByLogin.PasswordHash))
                return null;
            else
                return userByLogin;
        }

        public bool RegisterUser(User user, int userId)
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
                var newUser = _userRepository.GetByName(user.UserName);
                _auditLogService.Log(userId, "User", newUser.Id, "CREATE", null, newUser);
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
                var newUser = _userRepository.GetByName(login);
                _auditLogService.Log(newUser.Id, "User", newUser.Id, "CREATE", null, newUser);
                return (null, _userRepository.GetByLogin(login));
            }
            catch
            {
                return ("idk", null);
            }
        }

        public bool ResetPassword(string login, string passwordOld, string passwordNew, int userId)
        {
            var oldUser = _userRepository.GetByLogin(login);
            if (!BCrypt.Net.BCrypt.Verify(passwordOld, oldUser.PasswordHash))
                return false;
            oldUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(passwordNew);
            _userRepository.Update(oldUser);
            var newUser = _userRepository.GetByName(login);
            _auditLogService.Log(userId, "User", newUser.Id, "UPDATE", oldUser, newUser);
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
