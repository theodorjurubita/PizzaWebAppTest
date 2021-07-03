using System.ComponentModel;

namespace PizzaWebAppTest.Models
{
    public class OrderProduct
    {
        [DisplayName("Id Produs Livrare")]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
