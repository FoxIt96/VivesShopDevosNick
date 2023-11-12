using Microsoft.AspNetCore.Mvc;
using VivesShopDevosNick.UI.MVC.Models;


public class OrderController : Controller
{
    private IOrderRepository repository;
    private Cart cart;

    public OrderController(IOrderRepository repoService, Cart cartService)
    {
        repository = repoService;
        cart = cartService;
    }
    [HttpGet]
    public ViewResult Checkout()
    {
        var order = new Order();
        order.Items = cart.Items.ToList();
        return View(order);
    }

    [HttpPost]
    public IActionResult Checkout(Order order)
    {
        if (cart.Items.Count() == 0)
        {
            ModelState.AddModelError("", "Sorry, your cart is empty");
        }

        if (ModelState.IsValid)
        {
            order.Items = cart.Items.ToArray();
            order.PaymentMethod = order.PaymentMethod;
            repository.SaveOrder(order);
            cart.Clear();
            return View("Completed", order);
        }
        else
        {
            order.Items = cart.Items.ToList();
            return View(order);
        }
    }
}