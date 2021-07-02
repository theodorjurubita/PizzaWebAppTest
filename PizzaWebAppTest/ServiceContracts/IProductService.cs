using PizzaWebAppTest.RepositoryContracts;
using System.Threading.Tasks;

namespace PizzaWebAppTest.ServiceContracts
{
    public interface IProductService
    {
        IProductRepository ProductRepository { get; }
        Task<int> Commit();
    }
}
