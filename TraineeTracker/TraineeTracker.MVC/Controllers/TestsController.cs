using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeTracker.MVC.Contracts;
using TraineeTracker.MVC.Models;

namespace TraineeTracker.MVC.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize(Roles = "Trainee")]
    public class TestsController : Controller
    {
        private readonly ITestService _testService;

        public TestsController(ITestService testService)
        {
            _testService = testService;
        }

        [Route("/Tests")]
        public async Task<IActionResult> Index(string searchString, string sortOrder, string[] filters)
        {
            ViewData["Sort"] = sortOrder;
            ViewData["Search"] = searchString;
            ViewData["Filters"] = filters;

            var model = await _testService.GetCategories(searchString, sortOrder, filters);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTest(CategoryVM category)
        {
            if (ModelState.IsValid)
            {
                var response = await _testService.CreateTest(category.Id);
                if (response.Success)
                {
                    TempData["TestId"] = response.Data;
                    return RedirectToAction(nameof(Category), new { category = category.Name, q = 1 });
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }

            return RedirectToAction(nameof(Index));
        }

        [Route("/Tests/{category}")]
        public async Task<IActionResult> Category(string category, int? q)
        {
            if(TempData["TestId"] == null) return BadRequest();

            var model = await _testService.GetQuestionWithCount(category, q ?? 1);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAnswer(CreateAnswerVM answerVM, string category, int q, int total, int count)
        {
            int testId = await _testService.GetLatestTraineeTestId();
            TempData["TestId"] = testId;

            if (ModelState.IsValid)
            {
                var response = await _testService.CreateAnswer(answerVM, testId, q-1, count);
                if (!response.Success)
                    ModelState.AddModelError("", response.ValidationErrors);
            }

            if(q <= total)
                return RedirectToAction(nameof(Category), new { category, q });

            return RedirectToAction(nameof(Result));
        }

        public async Task<IActionResult> Result()
        {
            if (TempData["TestId"] == null) return BadRequest();

            var result = await _testService.GetResult();
            return View(result);
        }

        public async Task<IActionResult> Review(int testId, string category, int? q)
        {
            var model = await _testService.GetReviewVM(testId, q ?? 1, category);
            return View(model);
        }

        public async Task<IActionResult> Reviews(string searchString, string sortOrder, string[] filters, int? page)
        {
            ViewData["Sort"] = sortOrder;
            ViewData["Search"] = searchString;
            ViewData["Filters"] = filters;

            var model = await _testService.GetReviewListVM(searchString, sortOrder, filters, page);
            return View(model);
        }
    }
}
