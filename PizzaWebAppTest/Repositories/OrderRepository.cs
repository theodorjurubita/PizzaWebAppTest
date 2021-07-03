using Microsoft.EntityFrameworkCore;
using PizzaWebAppTest.Data;
using PizzaWebAppTest.Models;
using PizzaWebAppTest.RepositoryContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaWebAppTest.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async void DeleteOrder(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            _context.Orders.Remove(order);
        }

        public async Task<Order> GetOrderByID(int? orderId)
        {
            var order = await _context.Orders
                .Include(o => o.ContactDetails)
                .FirstOrDefaultAsync(m => m.Id == orderId);
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _context.Orders.Include(o => o.ContactDetails).ToListAsync();
        }

        public void InsertOrder(Order order)
        {
            _context.Add(order);
        }

        public void UpdateOrder(Order order)
        {
            _context.Update(order);
        }
    }
}
