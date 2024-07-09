using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class MasonryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
