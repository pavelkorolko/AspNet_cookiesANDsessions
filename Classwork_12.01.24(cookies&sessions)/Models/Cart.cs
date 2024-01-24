namespace Classwork_12._01._24_cookies_sessions_.Models
{
    public class Cart
    {
        public string UserId { get; set; }

        public List<OrderedProduct> ChosenProducts { get; set; }

        public Cart() { 
            ChosenProducts = new List<OrderedProduct>();
        }

        public void AddProduct(OrderedProduct product)
        {
            ChosenProducts.Add(product);
        }
    }
}
