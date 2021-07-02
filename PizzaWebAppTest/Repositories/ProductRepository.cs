using Microsoft.EntityFrameworkCore;
using PizzaWebAppTest.Data;
using PizzaWebAppTest.Models;
using PizzaWebAppTest.RepositoryContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaWebAppTest.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async void DeleteProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            _context.Products.Remove(product);
        }

        public async Task<Product> GetProductByID(int? productId)
        {
            var product = await _context.Products
                 .FirstOrDefaultAsync(m => m.Id == productId);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public void InsertProduct(Product product)
        {
            _context.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            _context.Update(product);
        }
    }
}
