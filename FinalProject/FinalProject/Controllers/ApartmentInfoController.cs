using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class ApartmentInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
