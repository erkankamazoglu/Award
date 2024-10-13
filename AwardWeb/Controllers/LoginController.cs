using System.Linq.Expressions;
using AwardEntity;
using AwardService;
using Microsoft.AspNetCore.Mvc;
using Utility.Auth;
using Utility.Http;
using Utility.Model.Auth;
using Utility.Security;

namespace AwardWeb.Controllers
{
    public class LoginController : Controller
    { 
        private UserService _userService; 
        public LoginController(UserService userService)
        {
            _userService = userService;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(IFormCollection collection)
        {  
            string email = collection["Email"];
            string password = collection["Password"]; 

            User? user = _userService.GetAll(new List<Expression<Func<User, bool>>>
            {
                user => user.Email == email
            }).FirstOrDefault();

            string errorMessage;
            if (user != null)
            { 
                bool isCorrect = PasswordHash.Verify(user.Password, password);

                if (isCorrect)
                {
                    AuthenticationModel authenticationModel = new AuthenticationModel(user.Id, user.Name, user.Surname, user.Email, user.UserRole); 
                    AuthenticationHelper.SignIn(authenticationModel); 
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    errorMessage = "Kullanıcı adı veya şifre hatalı";
                }
            }
            else
            {
                errorMessage = "Kullanıcı adı veya şifre hatalı";
            } 

            ViewData["ErrorMessage"] = errorMessage;
            return View();
        }
    }
}
