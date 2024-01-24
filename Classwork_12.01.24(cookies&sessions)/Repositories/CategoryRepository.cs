using Classwork_12._01._24_cookies_sessions_.Interfaces;
using Classwork_12._01._24_cookies_sessions_.Models;

namespace Classwork_12._01._24_cookies_sessions_.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationContext _context;

        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.FirstOrDefault(e => e.Id == id);
        }

        public Category GetCategoryByName(string name)
        {
            return _context.Categories.FirstOrDefault(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

    }
}
