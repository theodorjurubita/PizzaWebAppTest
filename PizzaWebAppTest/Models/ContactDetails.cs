using Microsoft.AspNetCore.Identity;

namespace PizzaWebAppTest.Models
{
    public class ContactDetails
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
