using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VivesShopDevosNick.UI.MVC.Infrastructure;
using VivesShopDevosNick.UI.MVC.Models;

public class HomeController : Controller
{
    private IStoreRepository repository;
    private Cart _cart;

    public HomeController(IStoreRepository repo, Cart cart)
    {
        repository = repo;
        _cart = cart;
    }

    public IActionResult Index()
    {
        var productList = repository.Products.ToList();
        var productCartViewModel = new ProductViewModel
        {
            Products = productList,
            Cart = _cart
        };

        return View(productCartViewModel);
    }

    [HttpPost]
    public IActionResult AddToCart(int productID)
    {
        var product = repository.Products.FirstOrDefault(p => p.ProductID == productID);

        if (product != null)
        {
            _cart.AddItem(product, 1);
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult RemoveFromCart(int productID)
    {
        var product = repository.Products.FirstOrDefault(p => p.ProductID == productID);

        if (product != null)
        {
            _cart.RemoveItem(product);
        }

        return RedirectToAction("Index");
    }

}