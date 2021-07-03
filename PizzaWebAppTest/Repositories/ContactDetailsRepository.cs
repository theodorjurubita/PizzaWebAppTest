using Microsoft.EntityFrameworkCore;
using PizzaWebAppTest.Data;
using PizzaWebAppTest.Models;
using PizzaWebAppTest.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzaWebAppTest.Repositories
{
    public class ContactDetailsRepository : IContactDetailsRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactDetailsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async void DeleteContactDetailsAsync(int contactDetailsId)
        {
            var contactDetails = await _context.ContactDetailsList.FindAsync(contactDetailsId);
            _context.ContactDetailsList.Remove(contactDetails);
        }

        public async Task<ContactDetails> GetContactDetailByID(int? contactDetailsId)
        {
            return await _context.ContactDetailsList.FindAsync(contactDetailsId);
        }

        public async Task<IEnumerable<ContactDetails>> GetContactDetails()
        {
            return await _context.ContactDetailsList.ToListAsync();
        }

        public void InsertContactDetail(ContactDetails contactDetails)
        {
            _context.Add(contactDetails);
        }

        public void UpdateContactDetail(ContactDetails contactDetails)
        {
            _context.Update(contactDetails);
        }
    }
}
