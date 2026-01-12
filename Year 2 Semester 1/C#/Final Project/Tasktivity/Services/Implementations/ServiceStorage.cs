using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class ServiceStorage
    {
        public TaskSizeService _taskSizeServ;
        public CategoryService _categoryServ;
        public TaskService _taskServ;
        public UserService _userServ;
        public ThemeService _themeServ;

        public ServiceStorage(RepositoryStorage repositoryStorage)
        {
            _taskSizeServ = new TaskSizeService(repositoryStorage._taskSizeRepo);
            _categoryServ = new CategoryService(repositoryStorage._categoryRepo);
            _taskServ = new TaskService(repositoryStorage._taskRepo);
            _userServ = new UserService(repositoryStorage._userRepo);
            _themeServ = new ThemeService(repositoryStorage._themeRepo);
        }
    }
}
