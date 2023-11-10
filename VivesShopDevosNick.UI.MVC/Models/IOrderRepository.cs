using VivesShopDevosNick.UI.MVC.Core;
namespace VivesShopDevosNick.UI.MVC.Models
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }
        void SaveOrder(Order order);
    }
}
