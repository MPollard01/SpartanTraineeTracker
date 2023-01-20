using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeTracker.MVC.Contracts;
using TraineeTracker.MVC.Models;

namespace TraineeTracker.MVC.Controllers
{
    [Authorize]
    public class TrackerController : Controller
    {
        private readonly ITrackerService _trackerService;

        public TrackerController(ITrackerService trackerService)
        {
            _trackerService = trackerService;
        }

        [Authorize(Roles = "Trainee")]
        public async Task<IActionResult> Index()
        {
            var model = await _trackerService.GetTracker(1);
            return View(model);
        }

        [Authorize(Roles = "Trainee")]
        public async Task<IActionResult> Trackers(string searchString, string sortOrder,
            string[] filter, int? pageNumber)
        {
            ViewData["Sort"] = sortOrder;
            ViewData["Search"] = searchString;
            ViewData["Filter"] = filter;

            var model = await _trackerService
                .GetTraineeTrackers(searchString, sortOrder, filter, pageNumber);
            return View(model);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Trainees(string searchString, string sortOrder,
            string[] filter, int? pageNumber)
        {
            ViewData["Sort"] = sortOrder;
            ViewData["Search"] = searchString;
            ViewData["Filter"] = filter;

            var model = await _trackerService
                .GetTrackers(searchString, sortOrder, filter, pageNumber);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Trainee")]
        public async Task<IActionResult> CreateTracker(CreateTrackerVM trackerVM)
        {
            if (ModelState.IsValid)
            {
                var response = await _trackerService.CreateTracker(trackerVM);
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
