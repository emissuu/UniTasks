using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Implementations;

namespace Services.Implementations
{
    public class CategoryService
    {
        private readonly CategoryRepository _repo;
        public CategoryService(CategoryRepository repo) => _repo = repo;
        public IEnumerable<Category> GetAll() => _repo.GetAll();
    }
}