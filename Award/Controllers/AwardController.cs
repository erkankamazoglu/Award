using AwardWeb.Models;
using AwardWeb.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace AwardWeb.Controllers
{
    public class AwardController : Controller
    {
        private readonly ModelContext _context;

        public AwardController(ModelContext context)
        {
            _context = context;
        }

        public IActionResult List()
        {
            List<Award> awards = _context.Award.ToList();
            return View(awards);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<Category> categories = _context.Category.ToList();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Award award)
        {
            _context.Award.Add(award);
            _context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Edit(int id)
        {
            Award user = _context.Award.Find(id)!;
            List<Category> categories = _context.Category.ToList();
            ViewBag.Categories = categories;
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Award award)
        {
            _context.Award.Update(award);
            _context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            Award? award = _context.Award.Find(id);
            if (award != null)
            {
                _context.Award.Remove(award);
                _context.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}
