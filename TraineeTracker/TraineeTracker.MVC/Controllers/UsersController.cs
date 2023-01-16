using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeTracker.MVC.Contracts;
using TraineeTracker.MVC.Models;

namespace TraineeTracker.MVC.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITrainerService _trainerService;

        public UsersController(IUserService userService, ITrainerService trainerService)
        {
            _userService = userService;
            _trainerService = trainerService;
        }

        public async Task<ActionResult> Index()
        {
            var model = await _userService.GetUserAdminList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTrainer(RegisterTrainerVM trainer)
        {
            if (ModelState.IsValid)
            {
                var response = await _trainerService.CreateTrainer(trainer);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
