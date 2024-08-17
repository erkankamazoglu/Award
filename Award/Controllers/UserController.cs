using AwardEntity;
using AwardEntity.Base;
using Microsoft.AspNetCore.Mvc;

namespace AwardWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly ModelContext _context;

        public UserController(ModelContext context)
        {
            _context = context;
        }

        public IActionResult List()
        {
            List<User> users = _context.User.ToList();
            return View(users);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Edit(int id)
        {
            User user = _context.User.Find(id)!;
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User user)
        {
            user.UpdateDate = DateTime.Now;
            _context.User.Update(user);
            _context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            User? user = _context.User.Find(id);
            if (user != null)
            {
                _context.User.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}