using AwardEntity; 
using AwardService;
using Microsoft.AspNetCore.Mvc; 

namespace AwardWeb.Controllers
{
    public class UserAwardController : Controller
    {
        private readonly UserAwardService _userAwardService; 
        private readonly UserService _userService; 
        private readonly AwardService.AwardService _awardService; 

        public UserAwardController(UserAwardService userAwardService, UserService userService, AwardService.AwardService awardService)
        {
            _userAwardService = userAwardService;
            _userService = userService;
            _awardService = awardService;
        }

        public IActionResult List()
        {
            List<UserAward> userAwards = _userAwardService.GetAll(new List<string>
            { 
                nameof(UserAward.User),
                nameof(UserAward.Award)
            }).ToList(); 

            return View(userAwards);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<User> users = _userService.GetAll().ToList();
            List<Award> awards = _awardService.GetAll().ToList();

            ViewBag.Users = users;
            ViewBag.Awards = awards;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(UserAward userAward)
        {
            _userAwardService.Add(userAward); 
            return RedirectToAction("List");
        }

        public IActionResult Edit(int id)
        {
            UserAward userAward = _userAwardService.GetById(id)!;
            List<User> users = _userService.GetAll().ToList();
            List<Award> awards = _awardService.GetAll().ToList();

            ViewBag.Users = users;
            ViewBag.Awards = awards;
            return View(userAward);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserAward userAward)
        {
            _userAwardService.Update(userAward);
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            _userAwardService.Delete(id);
            return RedirectToAction("List");
        }
    }
}
