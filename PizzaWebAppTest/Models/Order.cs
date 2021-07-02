using System;

namespace PizzaWebAppTest.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ContactDetailsId { get; set; }
        public ContactDetails ContactDetails { get; set; }
        public DateTime DateOfOrder { get; set; }
    }
}
