using Microsoft.EntityFrameworkCore;
using VivesShopDevosNick.UI.MVC.Core;
using VivesShopDevosNick.UI.MVC.Models;


namespace VivesShopDevosNick.UI.MVC.Models
{
	public class EFStoreRepository : IStoreRepository 
	{
		private StoreDbContext context;

		public EFStoreRepository(StoreDbContext ctx)
		{
			context = ctx;
		}
        public IQueryable<Product> Products => context.Products;
      
    }
}

