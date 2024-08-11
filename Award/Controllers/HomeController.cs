using Award.Models;
using Award.Models.Base;
using Microsoft.AspNetCore.Mvc; 

namespace Award.Controllers
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
            List<User> users = _context.User.ToList();

            _context.User.Add(new User { Name = "Test", Email = "", Surname = "Test2", Password = "AAA"});

            _context.User. 
            return View(users);
        }
    }
}
