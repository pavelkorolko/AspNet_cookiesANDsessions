using Classwork_12._01._24_cookies_sessions_.Interfaces;
using Classwork_12._01._24_cookies_sessions_.Models;
using Microsoft.EntityFrameworkCore;

namespace Classwork_12._01._24_cookies_sessions_.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            this._context = context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.Include(e => e.Category).ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(e => e.Id == id);
        }

        public List<Product> GetProductsByName(string name, int categoryId)
        {
            return _context.Products
                .Include(e => e.Category)
                .Where(e => e.Name.ToLower().Contains(name.ToLower()) &&
                e.Category.Id.Equals(categoryId))
                .ToList();
        }

        public void InitializeWithData()
        {
            List<Category> categories = new List<Category>
            {
                new Category{Name = "Electronics"},
                new Category{Name = "Clothing"},
                new Category{Name = "Home and Kitchen"},
                new Category{Name = "Books"},
                new Category{Name = "Beauty"},
            };

            _context.Categories.AddRange(categories);
            _context.SaveChanges();


            List<Product> products = new List<Product>
            {
                new Product{Name="Laptop - MacBook Pro", Description="Powerful and sleek laptop, ideal for creative professionals with its high-resolution Retina display and fast performance.", CategoryId = _context.Categories.FirstOrDefault(c => c.Name == "Electronics").Id, Price= 1500, Picture = "https://images.pexels.com/photos/303383/pexels-photo-303383.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", Amount = 100},
                new Product{Name="Smartphone - Samsung Galaxy S21", Description = "Cutting-edge smartphone featuring a stunning camera system, vibrant AMOLED display, and robust processing power.", Price= 500, CategoryId = _context.Categories.FirstOrDefault(c => c.Name == "Electronics").Id, Picture = "https://images.pexels.com/photos/214487/pexels-photo-214487.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", Amount = 500},
                new Product { Name = "T-Shirt", Description = "Comfortable cotton T-shirt in various colors", CategoryId = _context.Categories.FirstOrDefault(c => c.Name == "Clothing").Id, Price= 200, Picture = "https://images.pexels.com/photos/996329/pexels-photo-996329.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" , Amount = 750},
                new Product { Name = "Jeans", Description = "Classic denim jeans for a stylish look", CategoryId = _context.Categories.FirstOrDefault(c => c.Name == "Clothing").Id, Price= 120, Picture = "https://images.pexels.com/photos/603022/pexels-photo-603022.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", Amount = 350},
                new Product { Name = "Coffee Maker", Description = "Automatic coffee maker for brewing delicious coffee", CategoryId = _context.Categories.FirstOrDefault(c => c.Name == "Home and Kitchen").Id, Price= 100, Picture = "https://images.pexels.com/photos/1271940/pexels-photo-1271940.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",  Amount = 550 },
                new Product { Name = "Gardening Kit", Description = "Complete kit for gardening enthusiasts", CategoryId = _context.Categories.FirstOrDefault(c => c.Name == "Home and Kitchen").Id, Price = 200, Picture = "https://images.pexels.com/photos/6231714/pexels-photo-6231714.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",  Amount = 500 },
                new Product { Name = "Headphones", Description = "Over-ear headphones for immersive audio experience", CategoryId = _context.Categories.FirstOrDefault(c => c.Name == "Electronics").Id, Price = 110, Picture = "https://images.pexels.com/photos/1649771/pexels-photo-1649771.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",  Amount = 540 },
                new Product { Name = "Sneakers", Description = "Sporty sneakers for an active lifestyle", CategoryId = _context.Categories.FirstOrDefault(c => c.Name == "Clothing").Id, Price = 90, Picture = "https://images.pexels.com/photos/2529148/pexels-photo-2529148.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", Amount = 400},
                new Product { Name = "Blender", Description = "High-speed blender for smoothies and shakes", CategoryId = _context.Categories.FirstOrDefault(c => c.Name == "Home and Kitchen").Id, Price = 80,  Picture = "https://images.pexels.com/photos/1797103/pexels-photo-1797103.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", Amount = 40 },
                new Product { Name = "Watch", Description = "Elegant wristwatch with a modern design", CategoryId = _context.Categories.FirstOrDefault(c => c.Name == "Clothing").Id, Price = 220, Picture = "https://images.pexels.com/photos/5065220/pexels-photo-5065220.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" , Amount = 350},
                new Product { Name = "Vacuum Cleaner", Description = "Powerful vacuum cleaner for efficient cleaning", CategoryId = _context.Categories.FirstOrDefault(c => c.Name == "Home and Kitchen").Id, Price = 120,  Picture = "https://images.pexels.com/photos/38325/vacuum-cleaner-carpet-cleaner-housework-housekeeping-38325.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", Amount = 500 },
                new Product { Name = "Camera", Description = "Digital camera for capturing memorable moments", CategoryId = _context.Categories.FirstOrDefault(c => c.Name == "Electronics").Id, Price = 750, Picture = "https://images.pexels.com/photos/243757/pexels-photo-243757.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", Amount = 400 },
                new Product { Name = "Mystery Novel", Description = "Engaging mystery novel that will keep you on the edge of your seat", CategoryId = _context.Categories.FirstOrDefault(c => c.Name == "Books").Id, Price = 10, Picture = "https://images.pexels.com/photos/8389779/pexels-photo-8389779.jpeg?auto=compress&cs=tinysrgb&w=600" , Amount = 300},
                new Product { Name = "Science Fiction Book", Description = "Exciting science fiction book with futuristic adventures", CategoryId = _context.Categories.FirstOrDefault(c => c.Name == "Books").Id, Price = 20, Picture = "https://images.pexels.com/photos/7034644/pexels-photo-7034644.jpeg?auto=compress&cs=tinysrgb&w=600", Amount = 100 },
                new Product { Name = "Makeup Set", Description = "Complete makeup set with a variety of beauty products", CategoryId = _context.Categories.FirstOrDefault(c => c.Name == "Beauty").Id, Price = 100, Picture = "https://images.pexels.com/photos/3373727/pexels-photo-3373727.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", Amount = 250 }
            };

            _context.Products.AddRange(products);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            var current = _context.Products.FirstOrDefault(e => e.Id == product.Id);

            if(current != null)
            {
                current.Picture = product.Picture;
                current.Price = product.Price;
                current.Amount = product.Amount;
                current.Description = product.Description;
                current.Name = product.Name;
                _context.Update(current);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
    }
}
