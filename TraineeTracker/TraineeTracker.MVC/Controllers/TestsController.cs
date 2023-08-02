using Microsoft.AspNetCore.Mvc;
using TraineeTracker.MVC.Contracts;

namespace TraineeTracker.MVC.Controllers
{
    [Route("[controller]/[action]")]
    public class TestsController : Controller
    {
        private readonly ITestService _testService;

        public TestsController(ITestService testService)
        {
            _testService = testService;
        }

        [Route("/Tests")]
        public async Task<IActionResult> Index()
        {
            var model = await _testService.GetCategories();
            return View(model);
        }

        [Route("/Tests/{type}")]
        public async Task<ActionResult> Type(string type)
        {
            var model = await _testService.GetSubCategories(type);
            return View(model);
        }

        [Route("/Tests/{category}/{q}")]
        public async Task<IActionResult> Category(string category, int q)
        {
            var model = await _testService.GetQuestionWithCount(category, q);
            return View(model);
        }
    }
}
