using System;
namespace VivesShopDevosNick.UI.MVC.Models
{
	public interface IStoreRepository
	{
		IQueryable<Product> Products { get; }
	}
}

