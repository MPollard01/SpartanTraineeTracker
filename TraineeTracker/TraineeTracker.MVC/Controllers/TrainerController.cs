using Microsoft.AspNetCore.Mvc;
using TraineeTracker.MVC.Contracts;

namespace TraineeTracker.MVC.Controllers
{
    public class TrainerController : Controller
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        public async Task<IActionResult> Details(string id)
        {
            var model = await _trainerService.GetTrainer(id);
            return View(model);
        }
    }
}
