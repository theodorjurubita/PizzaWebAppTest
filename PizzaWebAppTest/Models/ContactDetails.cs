using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace PizzaWebAppTest.Models
{
    public class ContactDetails
    {
        [DisplayName("ContactDetails Id")]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
