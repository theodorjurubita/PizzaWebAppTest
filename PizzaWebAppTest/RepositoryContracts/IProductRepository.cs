using PizzaWebAppTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaWebAppTest.RepositoryContracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductByID(int? productId);
        void InsertProduct(Product product);
        void DeleteProduct(int productId);
        void UpdateProduct(Product product);
    }
}
