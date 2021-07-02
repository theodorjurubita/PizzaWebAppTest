using PizzaWebAppTest.Data;
using PizzaWebAppTest.Repositories;
using PizzaWebAppTest.RepositoryContracts;
using PizzaWebAppTest.ServiceContracts;
using System.Threading.Tasks;

namespace PizzaWebAppTest.Services
{
    public class ProductService : IProductService
    {
        private ApplicationDbContext _context;
        private ProductRepository _products;
        public IProductRepository ProductRepository
        {
            get
            {
                return _products ??= new ProductRepository(_context);
            }
        }

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
