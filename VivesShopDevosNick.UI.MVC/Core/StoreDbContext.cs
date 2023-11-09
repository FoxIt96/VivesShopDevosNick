using Microsoft.EntityFrameworkCore;
using VivesShopDevosNick.UI.MVC.Models;

using System;
namespace VivesShopDevosNick.UI.MVC.Core
{
	public class StoreDbContext : DbContext
	{
		public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }
		public DbSet<Product> Products => Set<Product>();
	}
}

