using System.Linq.Expressions;
using AwardEntity;
using AwardService;
using Microsoft.AspNetCore.Mvc;
using Utility.Security;

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
