using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class FurnitureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
