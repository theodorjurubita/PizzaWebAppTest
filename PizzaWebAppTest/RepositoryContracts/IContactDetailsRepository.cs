using PizzaWebAppTest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaWebAppTest.RepositoryContracts
{
    public interface IContactDetailsRepository
    {
        Task<IEnumerable<ContactDetails>> GetContactDetails();
        Task<ContactDetails> GetContactDetailByID(int? contactDetailsId);
        void InsertContactDetail(ContactDetails contactDetails);
        void DeleteContactDetailsAsync(int contactDetailsId);
        void UpdateContactDetail(ContactDetails contactDetails);
    }
}
