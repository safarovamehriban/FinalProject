using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class Product1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
