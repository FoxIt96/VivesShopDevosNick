using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VivesShopDevosNick.UI.MVC.Models;

namespace VivesShopDevosNick.UI.MVC.Controllers;

public class HomeController : Controller
{
    private IStoreRepository repository;


    public HomeController(IStoreRepository repo, Cart cart)
    {
        repository = repo;
 
    }
 
    public IActionResult Index()
    {
     
        return View(repository.Products);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}

