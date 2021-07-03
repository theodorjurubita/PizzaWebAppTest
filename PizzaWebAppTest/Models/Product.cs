using System.ComponentModel;

namespace PizzaWebAppTest.Models
{
    public class Product
    {
        [DisplayName("Product Id")]
        public int Id { get; set; }
        [DisplayName("Denumire")]
        public string ProductName { get; set; }
        [DisplayName("Descriere")]
        public string ProductDescription { get; set; }
        [DisplayName("Pret")]
        public double Price { get; set; }
    }
}
