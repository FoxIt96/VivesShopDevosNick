using System;
using VivesShopDevosNick.UI.MVC.Models;
namespace VivesShopDevosNick.UI.MVC.Models
{
	public class Cart
	{
		public List<CartItem> Items { get; set; } = new List<CartItem>();

		public virtual void AddItem(Product product, int quantity)
		{
			CartItem? item = Items.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();

			if(item == null)
			{
				Items.Add(new CartItem
				{
					Product = product,
					Quantity = quantity
				});
			} else
			{
				item.Quantity += quantity;
			}
		}
		public virtual void RemoveItem(Product product) => Items.RemoveAll(i => i.Product.ProductID == product.ProductID);

		public double CalculateTotalPrice() => Items.Sum(e => e.Product.Price * e.Quantity);

		public virtual void Clear() => Items.Clear();
	}
}

