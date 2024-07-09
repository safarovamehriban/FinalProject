using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
