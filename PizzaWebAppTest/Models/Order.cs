using System;
using System.ComponentModel;

namespace PizzaWebAppTest.Models
{
    public class Order
    {
        [DisplayName("Order Id")]
        public int Id { get; set; }
        public int ContactDetailsId { get; set; }
        public ContactDetails ContactDetails { get; set; }
        public DateTime DateOfOrder { get; set; }
    }
}
