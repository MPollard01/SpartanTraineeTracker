using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeTracker.MVC.Contracts;

namespace TraineeTracker.MVC.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [Route("profile")]
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Trainee"))
            {
                var model = await _profileService.GetTraineeProfile();
                return View("TraineeProfile", model);
            }

            return View();
        }

        
    }
}
