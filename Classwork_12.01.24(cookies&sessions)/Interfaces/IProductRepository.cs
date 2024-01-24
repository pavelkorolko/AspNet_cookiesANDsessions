using Classwork_12._01._24_cookies_sessions_.Models;

namespace Classwork_12._01._24_cookies_sessions_.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        void InitializeWithData();
        List<Product> GetProductsByName(string name, int categoryId);
        Product GetProductById(int id);
        void UpdateProduct(Product product);
    }
}
