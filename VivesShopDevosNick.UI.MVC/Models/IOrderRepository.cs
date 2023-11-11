// IOrderRepository.cs

using System.Linq;

namespace VivesShopDevosNick.UI.MVC.Models
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);

        Order GetOrderById(int orderId);
    }
}
