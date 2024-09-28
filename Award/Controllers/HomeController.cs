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
            string email = "melisa.irem@gmail.com";
            string password = "1234";


            User? user = _userService.GetAll(new List<Expression<Func<User, bool>>>
            {
                i => i.Email == email
            }).FirstOrDefault();

            if (user != null)
            {
                bool isCorrect = PasswordHash.Verify(user.Password, password);
            }


            

            return View();
        }
    }
}
