using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaWebAppTest.Data;
using PizzaWebAppTest.Models;

namespace PizzaWebAppTest.Controllers
{
    public class ContactDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContactDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactDetailsList.ToListAsync());
        }

        // GET: ContactDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactDetails = await _context.ContactDetailsList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactDetails == null)
            {
                return NotFound();
            }

            return View(contactDetails);
        }

        // GET: ContactDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Address,FirstName,LastName,UserId")] ContactDetails contactDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactDetails);
        }

        // GET: ContactDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactDetails = await _context.ContactDetailsList.FindAsync(id);
            if (contactDetails == null)
            {
                return NotFound();
            }
            return View(contactDetails);
        }

        // POST: ContactDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Address,FirstName,LastName,UserId")] ContactDetails contactDetails)
        {
            if (id != contactDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactDetailsExists(contactDetails.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contactDetails);
        }

        // GET: ContactDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactDetails = await _context.ContactDetailsList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactDetails == null)
            {
                return NotFound();
            }

            return View(contactDetails);
        }

        // POST: ContactDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactDetails = await _context.ContactDetailsList.FindAsync(id);
            _context.ContactDetailsList.Remove(contactDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: ContactDetailsByUserId
        public async Task<IActionResult> ContactDetailsByUserId(string userId)
        {
            return View("Index", await _context.ContactDetailsList.Where(c => c.UserId == userId).ToListAsync());
        }

        private bool ContactDetailsExists(int id)
        {
            return _context.ContactDetailsList.Any(e => e.Id == id);
        }
    }
}
