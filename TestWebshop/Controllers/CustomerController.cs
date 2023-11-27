using Microsoft.AspNetCore.Mvc;

namespace TestWebshop.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
