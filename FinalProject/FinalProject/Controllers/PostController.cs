using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
