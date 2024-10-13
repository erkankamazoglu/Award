using AwardService;
using Microsoft.AspNetCore.Mvc; 

namespace AwardWeb.Controllers
{
    public class HomeController : Controller
    {
        private UserService _userService;

        public HomeController(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
