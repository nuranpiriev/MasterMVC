﻿using Microsoft.AspNetCore.Mvc;

namespace Purple_Buzz.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
