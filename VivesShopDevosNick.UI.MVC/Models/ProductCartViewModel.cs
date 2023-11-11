namespace VivesShopDevosNick.UI.MVC.Models
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

    }
}