using Microsoft.AspNetCore.Mvc;

namespace PizzaWebAppTest.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
