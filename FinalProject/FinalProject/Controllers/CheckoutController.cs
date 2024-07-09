using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
