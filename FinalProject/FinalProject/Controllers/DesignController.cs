﻿using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class DesignController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
