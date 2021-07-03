using PizzaWebAppTest.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaWebAppTest.ServiceContracts
{
    public interface IOrderService
    {
        IContactDetailsRepository ContactDetailsRepository { get; }
        IOrderRepository OrderRepository { get; }
        Task<int> Commit();
    }
}
