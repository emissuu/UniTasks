using Microsoft.EntityFrameworkCore;

namespace Repositories.Implementations
{
    public class RepositoryStorage
    {
        public TaskSizeRepository _taskSizeRepo;
        public CategoryRepository _categoryRepo;
        public TaskRepository _taskRepo;
        public UserRepository _userRepo;
        public ThemeRepository _themeRepo;

        public RepositoryStorage(DbContext context)
        {
            _taskSizeRepo = new TaskSizeRepository(context);
            _categoryRepo = new CategoryRepository(context);
            _taskRepo = new TaskRepository(context);
            _userRepo = new UserRepository(context);
            _themeRepo = new ThemeRepository(context);
        }
    }
}
