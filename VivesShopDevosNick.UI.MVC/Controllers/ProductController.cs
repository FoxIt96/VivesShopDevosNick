using Microsoft.AspNetCore.Mvc;
using VivesShopDevosNick.UI.MVC.Core;
using VivesShopDevosNick.UI.MVC.Models;
using System;

namespace VivesShopDevosNick.UI.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly StoreDbContext _dbContext;

        public ProductController(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var product = _dbContext.Products.ToList();
            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.ProductID == id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var dbProduct = _dbContext.Products.FirstOrDefault(p => p.ProductID == id);

            if (dbProduct is null)
            {
                return RedirectToAction("Index");
            }

            dbProduct.Name = product.Name;
            dbProduct.Price = product.Price;

            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete([FromRoute] int id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.ProductID == id);
            return View(product);
        }

        [HttpPost("/Product/delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed([FromRoute] int id)
        {
            var dbProduct = _dbContext.Products.FirstOrDefault(p => p.ProductID == id);

            if (dbProduct is null)
            {
                return RedirectToAction("Index");
            }

            _dbContext.Products.Remove(dbProduct);

            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
