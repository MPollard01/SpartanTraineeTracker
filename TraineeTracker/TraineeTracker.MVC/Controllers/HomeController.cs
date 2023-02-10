using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TraineeTracker.MVC.Contracts;
using TraineeTracker.MVC.Models;

namespace TraineeTracker.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _homeService;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            if(User.IsInRole("Administrator"))
            {
                var model = await _homeService.GetAdminHome();
                return View("Admin_Home", model);
            }

            if (User.IsInRole("Trainer"))
            {
                var model = await _homeService.GetTrainerHome();
                return View("TrainerHome", model);
            }

            if (User.IsInRole("Trainee"))
            {
                var model = await _homeService.GetTraineeHome();
                return View("TraineeHome", model);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}