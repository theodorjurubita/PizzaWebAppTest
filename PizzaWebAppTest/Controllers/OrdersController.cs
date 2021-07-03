using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaWebAppTest.Models;
using PizzaWebAppTest.RepositoryContracts;
using PizzaWebAppTest.ServiceContracts;

namespace PizzaWebAppTest.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _orderService.OrderRepository.GetOrders());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _orderService.OrderRepository.GetOrderByID(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public async Task<IActionResult> Create()
        {
            ViewData["ContactDetailsId"] = new SelectList(await _orderService.ContactDetailsRepository.GetContactDetails(), "Id", "Id");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContactDetailsId,DateOfOrder")] Order order)
        {
            if (ModelState.IsValid)
            {
                _orderService.OrderRepository.InsertOrder(order);
                await _orderService.Commit();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContactDetailsId"] = new SelectList(await _orderService.ContactDetailsRepository.GetContactDetails(), "Id", "Id", order.ContactDetailsId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _orderService.OrderRepository.GetOrderByID(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["ContactDetailsId"] = new SelectList(await _orderService.ContactDetailsRepository.GetContactDetails(), "Id", "Email", order.ContactDetailsId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContactDetailsId,DateOfOrder")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _orderService.OrderRepository.UpdateOrder(order);
                    await _orderService.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await OrderExists(order.Id))
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
            ViewData["ContactDetailsId"] = new SelectList(await _orderService.ContactDetailsRepository.GetContactDetails(), "Id", "Id", order.ContactDetailsId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _orderService.OrderRepository.GetOrderByID(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _orderService.OrderRepository.DeleteOrder(id);
            await _orderService.Commit();
            return RedirectToAction(nameof(Index));
        }

        // GET: OrdersByUser
        public async Task<IActionResult> GetOrdersByUser(string userId)
        {
            var orders = await _orderService.OrderRepository.GetOrders();
            var ordersByUser = orders.Where(o => o.ContactDetails.UserId == userId);
            return View("Index", ordersByUser.ToList());
        }

        private async Task<bool> OrderExists(int id)
        {
            var orders = await _orderService.OrderRepository.GetOrders();
            return orders.Any(e => e.Id == id);
        }
    }
}
