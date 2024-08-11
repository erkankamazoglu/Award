using AwardWeb.Models;
using AwardWeb.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace AwardWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ModelContext _context;

        public HomeController(ModelContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        { 
            return View();
        }
    }
}
