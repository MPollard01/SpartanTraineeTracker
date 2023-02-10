using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeTracker.MVC.Contracts;
using TraineeTracker.MVC.Models;

namespace TraineeTracker.MVC.Controllers
{
    [Authorize]
    public class TraineeController : Controller
    {
        private readonly ITraineeService _traineeService;

        public TraineeController(ITraineeService traineeService)
        {
            _traineeService = traineeService;
        }

        public async Task<IActionResult> Index(string searchString, string sortOrder,
            string[] filter, int? pageNumber)
        {
            ViewData["Sort"] = sortOrder;
            ViewData["Search"] = searchString;
            ViewData["Filter"] = filter;

            var model = await _traineeService
                .GetTraineesByTrainer(searchString, sortOrder, filter, pageNumber);
            return View(model);
        }

        public async Task<IActionResult> Details(string id)
        {
            var trainee = await _traineeService.GetTraineeDetails(id);
            var skillCount = await _traineeService.GetTraineeSkillCount(id);

            var model = new TraineeAdminViewVM
            {
                Trainee = trainee,
                ConsultantSkillCount = skillCount.Item1,
                TechSkillCount = skillCount.Item2,
            };

            return View(model);
        }
    }
}
