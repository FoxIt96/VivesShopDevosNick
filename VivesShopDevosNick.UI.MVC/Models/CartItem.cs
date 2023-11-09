using System;
namespace VivesShopDevosNick.UI.MVC.Models
{
	public class CartItem
	{
		public int CartLineID { get; set; }
		public Product Product { get; set; } = new();
		public int Quantity { get; set; }
	}
}

