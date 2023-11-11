using System.Collections.Generic;
using System.Linq;

namespace VivesShopDevosNick.UI.MVC.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public virtual void AddItem(Product product, int quantity)
        {
            CartItem? item = Items.FirstOrDefault(p => p.Product.ProductID == product.ProductID);

            if (item == null)
            {
                Items.Add(new CartItem
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public virtual void RemoveItem(Product product) => Items.RemoveAll(i => i.Product.ProductID == product.ProductID);

        public double CalculateTotalPrice() => Items.Sum(e => e.Product.Price * e.Quantity);

        public virtual void Clear() => Items.Clear();

        // Add this method to allow enumeration of Cart items
        public IEnumerable<CartItem> GetItems() => Items;
    }
}