using AwardEntity; 
using AwardService;
using Microsoft.AspNetCore.Mvc; 

namespace AwardApi.Controllers
{
    [ApiController]
    public class UserAwardController : ControllerBase
    {
        private readonly UserAwardService _userAwardService;

        public UserAwardController(UserAwardService userAwardService)
        {
            _userAwardService = userAwardService;
        }

        [Route("Api/GetList")]
        [HttpGet]
        public List<UserAward> GetList()
        {  
            List<UserAward> userAwards = _userAwardService.GetAll(new List<string>
            {
                nameof(UserAward.User),
                nameof(UserAward.Award)
            }).ToList();
                
            return userAwards;
        }
    }
}
