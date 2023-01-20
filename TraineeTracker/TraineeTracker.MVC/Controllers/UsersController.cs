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
        private readonly ITraineeService _traineeService;

        public UsersController(IUserService userService, ITrainerService trainerService, 
            ITraineeService traineeService)
        {
            _userService = userService;
            _trainerService = trainerService;
            _traineeService = traineeService;
        }

        public async Task<ActionResult> Index(string searchString, string sortOrder, string[] filter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentFilter"] = searchString;
            ViewData["Filter"] = filter;

            var model = await _userService.GetUserAdminList(searchString, sortOrder, filter, pageNumber);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTrainee(RegisterTraineeVM trainer)
        {
            if (ModelState.IsValid)
            {
                var response = await _traineeService.CreateTrainee(trainer);
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
