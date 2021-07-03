using PizzaWebAppTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaWebAppTest.RepositoryContracts
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrderByID(int? orderId);
        void InsertOrder(Order order);
        void DeleteOrder(int orderId);
        void UpdateOrder(Order order);
    }
}
