﻿using Microsoft.AspNetCore.Mvc;

namespace AwardWeb.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
