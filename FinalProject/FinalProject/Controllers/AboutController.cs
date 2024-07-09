using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace FinalProject.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
