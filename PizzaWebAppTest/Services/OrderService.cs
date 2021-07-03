using PizzaWebAppTest.Data;
using PizzaWebAppTest.Repositories;
using PizzaWebAppTest.RepositoryContracts;
using PizzaWebAppTest.ServiceContracts;
using System.Threading.Tasks;

namespace PizzaWebAppTest.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private ContactDetailsRepository _contactDetails;
        private OrderRepository _orders;
        public IContactDetailsRepository ContactDetailsRepository
        {
            get
            {
                return _contactDetails ??= new ContactDetailsRepository(_context);
            }
        }
        public IOrderRepository OrderRepository
        {
            get
            {
                return _orders ??= new OrderRepository(_context);
            }
        }

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
