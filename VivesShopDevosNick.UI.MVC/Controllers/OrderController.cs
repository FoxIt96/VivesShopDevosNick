using Microsoft.AspNetCore.Mvc;
using VivesShopDevosNick.UI.MVC.Models;

using Microsoft.AspNetCore.Mvc;
using VivesShopDevosNick.UI.MVC.Models;
namespace VivesShopDevosNick.UI.MVC.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository;
        private Cart cart;

        public OrderController(IOrderRepository repoService, Cart cartService)
        {
            repository=repoService;
            cart=cartService;
        }

        public ViewResult Checkout() => View(new Order());

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Items.Count() == 0)
            {
                ModelState.AddModelError("","sorry, your cart is empty");
            }

            if (ModelState.IsValid)
            {
                order.Items = cart.Items.ToArray();
                repository.SaveOrder(order);
                cart.Clear();
                return RedirectToPage("/Completed", new { orderId = order.OrderID });
            }
            else
            {
                return View();
            }
        }

    }
}
