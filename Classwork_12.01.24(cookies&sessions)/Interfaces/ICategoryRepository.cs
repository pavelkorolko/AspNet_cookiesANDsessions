using Classwork_12._01._24_cookies_sessions_.Models;

namespace Classwork_12._01._24_cookies_sessions_.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        Category GetCategoryByName(string name);
        Category GetCategoryById(int id);
    }
}
