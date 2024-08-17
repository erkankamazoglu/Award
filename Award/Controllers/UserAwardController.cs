using AwardWeb.Models.Base;
using AwardWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AwardWeb.Controllers
{
    public class UserAwardController : Controller
    {
        private readonly ModelContext _context;

        public UserAwardController(ModelContext context)
        {
            _context = context;
        }

        public IActionResult List()
        {
            List<UserAward> userAwards = _context.UserAward
                .Include(ua => ua.User)
                .Include(ua => ua.Award).ToList();
            return View(userAwards);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<User> users = _context.User.ToList();
            List<Award> awards = _context.Award.ToList();

            ViewBag.Users = users;
            ViewBag.Awards = awards;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(UserAward userAward)
        {
            _context.UserAward.Add(userAward);
            _context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Edit(int id)
        {
            UserAward userAward = _context.UserAward.Find(id)!;
            List<User> users = _context.User.ToList();
            List<Award> awards = _context.Award.ToList();

            ViewBag.Users = users;
            ViewBag.Awards = awards;
            return View(userAward);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserAward userAward)
        {
            userAward.UpdateDate = DateTime.Now;
            _context.UserAward.Update(userAward);
            _context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            UserAward? userAward = _context.UserAward.Find(id);
            if (userAward != null)
            {
                _context.UserAward.Remove(userAward);
                _context.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}
