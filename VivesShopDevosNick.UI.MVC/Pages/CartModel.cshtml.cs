using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VivesShopDevosNick.UI.MVC.Models;

public class CartModel : PageModel
{
    private IStoreRepository repository;

    public CartModel(IStoreRepository repo, Cart cartService)
    {
        repository = repo;
        Cart = cartService;
    }

    public Cart Cart { get; set; }
    public string ReturnUrl { get; set; } = "/";

    public void OnGet(String returnUrl)
    {
        ReturnUrl = returnUrl ?? "/";
    }

    [HttpPost]
    public IActionResult OnPost(int productId, string returnUrl)
    {
        Product? product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
        if (product != null)
        {
            Cart.AddItem(product, 1);
        }

        return RedirectToPage(new { returnUrl = returnUrl });
    }

    public IActionResult OnPostRemove(int productId, string returnUrl)
    {
        Cart.RemoveItem(Cart.Items.First(cl => cl.Product.ProductID == productId).Product);
        return RedirectToPage(new { returnUrl = returnUrl });

    }
}