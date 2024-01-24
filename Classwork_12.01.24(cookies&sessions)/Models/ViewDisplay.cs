namespace Classwork_12._01._24_cookies_sessions_.Models
{
    public class ViewDisplay
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public string SelectedValue { get; set; }
        public string SelectedCategory { get; set; }
    }
}
