 using Classwork_12._01._24_cookies_sessions_.Interfaces;
using Classwork_12._01._24_cookies_sessions_.Models;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Completions;
using OpenAI_API;
using OpenAI_API.Moderation;
using Classwork_12._01._24_cookies_sessions_.API;
using System.Text.Json;

namespace Classwork_12._01._24_cookies_sessions_.Controllers
{
    public class HomeController : Controller
    {
        //1
        //Используя Cookie, добавьте значение и получите его в любом месте приложения.

        /*public IActionResult Index()
        {
            string result = "";
            if (HttpContext.Request.Cookies["name"] != null)
            {
                result = HttpContext.Request.Cookies["name"];
            }
            else
            {
                HttpContext.Response.Cookies.Append("name", "Tom");

            }
            return View("Index", result);
        }
        */

        //2
        //У вас есть веб-приложение, где пользователи могут добавлять товары в корзину и оформлять заказы.Ваша задача - использовать Session, чтобы сохранить состояние корзины
        //пользователя между запросами.Для этого вы должны создать метод-обработчик запроса, который будет вызываться при добавлении товара в корзину. В этом методе обновляйте
        //или создавайте Session, содержащую информацию о товарах в корзине. Вы можете использовать сериализацию JSON для преобразования списка товаров в строку и сохранения ее
        //в Session. Затем, когда пользователь переходит на страницу корзины или оформления заказа, вы можете считать данные из Session и использовать их для отображения товаров
        //в корзине или заполнения формы заказа.

        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(IUserRepository userRepository, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            if (HttpContext.Request.Cookies.ContainsKey("userid"))
            {
                return RedirectToAction("User");
            }
            //_userRepository.InitializeWithData();
            return View("Index", _userRepository.GetAllUsers());
        }
        public IActionResult SetUser(int id)
        {
            HttpContext.Response.Cookies.Append("userid", id.ToString());
            return RedirectToAction("User");
        }

        public IActionResult User()
        {
            if (HttpContext.Request.Cookies.ContainsKey("userid"))
            {
                //_productRepository.InitializeWithData();
                var categories = _categoryRepository.GetAllCategories();
                categories.Add(new Category { Id = 0, Name = "All" });

                var options = new ViewDisplay { Products = _productRepository.GetAllProducts(), Categories = categories};

                return View("Product", options);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Search(string input, int categoryId)
        {
            ViewDisplay options;
            var categories = _categoryRepository.GetAllCategories();
            categories.Add(new Category { Id = 0, Name = "All" });

            if (categoryId != 0)
            {
                var selectedProducts = _productRepository.GetProductsByName(input, categoryId);

                if (selectedProducts != null)
                {
                    options = new ViewDisplay { Products = selectedProducts, Categories = categories, SelectedValue = input, SelectedCategory = _categoryRepository.GetCategoryById(categoryId).Name};

                    return View("Product", options);
                }
            }

            options = new ViewDisplay { Products = _productRepository.GetAllProducts(), Categories = categories, SelectedValue = "", SelectedCategory = categories[0].Name };
            return View("Product", options);
        }

        public IActionResult Details(int productId, bool isClicked = false)
        {
            var currentProduct = _productRepository.GetProductById(productId);
            var api = new APIGTP();
            var result = api.GetResult(currentProduct.Name, currentProduct.Description)[0];

            ViewBag.Info = result;
            ViewBag.Clicked = isClicked;

            return View("Details", new ProductClickSateDisplay { CurrentProduct = currentProduct, ClickState = new ClickState(isClicked)});
        }

        [HttpPost]
        public IActionResult AddProductToCart(int productid, int amount)
        {
            var userid = HttpContext.Request.Cookies["key"];

            var currentProduct = _productRepository.GetProductById(productid);
            currentProduct.Amount -= amount;
            _productRepository.UpdateProduct(currentProduct);

            string convertedCart = null;

            if (!HttpContext.Session.Keys.Contains("cart"))
            {
                Cart cart = new Cart { UserId = HttpContext.Request.Cookies["userid"] };
                cart.AddProduct(new OrderedProduct { ProductId = productid, Amount = amount, Name = currentProduct.Name });
                convertedCart = JsonSerializer.Serialize<Cart>(cart);
            }
            else
            {
                var cart = HttpContext.Session.GetString("cart");
                var retrievedCart = JsonSerializer.Deserialize<Cart>(cart);

                retrievedCart.AddProduct(new OrderedProduct { ProductId = productid, Amount = amount, Name = currentProduct.Name});
                convertedCart = JsonSerializer.Serialize<Cart>(retrievedCart);
            }

            HttpContext.Session.SetString("cart", convertedCart);
            return RedirectToAction("User");
        }

        public IActionResult ShowCart()
        {
            Cart retrievedCart = null;
            if (HttpContext.Session.Keys.Contains("cart"))
            {
                var cart = HttpContext.Session.GetString("cart");
                retrievedCart = JsonSerializer.Deserialize<Cart>(cart);
            }
            else
            {
                ViewBag.Info = "There is no orders at this moment for you!";
            }

            return View("ShowCart", retrievedCart);
        }
    }
}