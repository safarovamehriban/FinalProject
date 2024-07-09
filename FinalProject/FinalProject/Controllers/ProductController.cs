using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
