// EFOrderRepository.cs

using System.Linq;
using Microsoft.EntityFrameworkCore;
using VivesShopDevosNick.UI.MVC.Core;

namespace VivesShopDevosNick.UI.MVC.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private StoreDbContext context;

        public EFOrderRepository(StoreDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Order> Orders => context.Orders.Include(o => o.Items).ThenInclude(l => l.Product);

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Items.Select(l => l.Product));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }

        // Implementeer de GetOrderById-methode
        public Order GetOrderById(int orderId)
        {
            return context.Orders.FirstOrDefault(o => o.OrderID == orderId);
        }
    }
}