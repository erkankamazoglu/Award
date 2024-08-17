using Microsoft.AspNetCore.Mvc;

namespace AwardWeb.Controllers
{
    public class HomeController : Controller
    { 
        public IActionResult Index()
        { 
            return View();
        }
    }
}
