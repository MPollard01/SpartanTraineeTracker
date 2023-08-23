using TraineeTracker.MVC.Contracts;
using TraineeTracker.MVC.Models;
using TraineeTracker.MVC.Services.Base;
using TraineeTracker.MVC.Utils;

namespace TraineeTracker.MVC.Services
{
    public class TestService : BaseHttpService, ITestService
    {
        public TestService(IClient client, ILocalStorageService localStorage) 
            : base(client, localStorage)
        {
        }

        public async Task<Response<int>> CreateTest(int categoryId)
        {
            try
            {
                var response = new Response<int>();
                var testDto = new CreateTraineeTestDto { SubCategoryId = categoryId };
                AddBearerToken();
          
                var apiResponse = await _client.TraineeTestPOSTAsync(testDto);

                if (apiResponse.Success)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                    response.Message = apiResponse.Message;
                }
                else
                {
                    response.ValidationErrors =
                        string.Join(Environment.NewLine, apiResponse.Errors);
                }

                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<CategoryListVM> GetCategories(string searchString, string sortOrder, string[] filters)
        {
            AddBearerToken();
            IEnumerable<CategoryDetailDto> filterList = await _client.CategoryAsync();
            IEnumerable<SubCategoryDetailDto> categories = await _client.SubCategoryAsync();

            if(filters.Length > 0)
            {
                categories = categories
                    .Where(c => filters
                    .Any(x => x == c.Name || x == c.Category.Name));

            }

            if (!string.IsNullOrEmpty(searchString))
            {
                categories = categories
                    .Where(c => c.Name
                    .StartsWith(searchString, StringComparison.OrdinalIgnoreCase) || c.Category.Name
                    .StartsWith(searchString, StringComparison.OrdinalIgnoreCase));
            }

            switch (sortOrder)
            {
                case "category":
                    categories = categories.OrderBy(c => c.Name);
                    break;
                case "language":
                    categories = categories.OrderBy(c => c.Category.Name);
                    break;
            }

            return new CategoryListVM
            {
                SubCategories = categories,
                FilterList = filterList
            };
        }

        public async Task<QuestionVM> GetQuestionWithCount(string category, int index)
        {
            AddBearerToken();
            var question = await _client.QuestionAsync(category, index);
            int count = await _client.QuestionGETCountAsync(category);
            int answerCount = await _client.AnswerGETCountAsync(question.Id);

            return new QuestionVM
            {
                Question = question,
                Count = count,
                Index = index,
                AnswerCount = answerCount,
                Category = category,
                Answer = new CreateAnswerVM { QuestionId = question.Id }
            };
        }

        public async Task<SubCategoryListVM> GetSubCategories(string category)
        {
            AddBearerToken();
            var subs = await _client.SubCategory2Async(category);
            return new SubCategoryListVM { Categories = subs };
        }

        public async Task<Response<int>> CreateAnswer(CreateAnswerVM answerVM, int testId, int q, int count)
        {
            try
            {
                var response = new Response<int>();
                AddBearerToken();

                var answers = answerVM.Answers.Where(x => x != "false");
                foreach(var answer in answers)
                {
                    var answerDto = new CreateTraineeAnswerDto
                    {
                        Answer = answer,
                        TraineeTestId = testId,
                        QuestionId = answerVM.QuestionId
                    };

                    var apiResponse = await _client.TraineeAnswerAsync(answerDto);

                    if (apiResponse.Success)
                    {
                        response.Success = true;
                        response.Message = apiResponse.Message;
                        
                        if(answers.Count() <= count)
                        {
                            await _client.TraineeTestPUTAsync(testId, apiResponse.Id, q);
                        }
                    }
                    else
                    {
                        response.ValidationErrors =
                            string.Join(Environment.NewLine, apiResponse.Errors);

                        response.Success = false;
                        break;
                    }
                    
                }

                return response;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<int> GetLatestTraineeTestId()
        {
            AddBearerToken();
            return await _client.TraineeTestGETLatestTestIdAsync();
        }

        public async Task<ResultVM> GetResult()
        {
            AddBearerToken();
            var test = await _client.TraineeTestGETLatestTestWithCategoryAsync();
            var count = await _client.AnswerGETCountTotalAsync(test.SubCategory.Id);

            return new ResultVM
            {
                TestId = test.Id,
                Score = test.Score,
                TestName = test.SubCategory.Name,
                Total = count
            };
        }

        public async Task<ReviewVM> GetReviewVM(int testId, int index, string category)
        {
            AddBearerToken();
            var question = await _client.QuestionAsync(category, index);
            var traineeAnswers = await _client.TraineeAnswerGETAnswersByQuestionIdAsync(testId, question.Id);
            var answers = await _client.AnswerAsync(question.Id);
            int count = await _client.QuestionGETCountAsync(category);

            return new ReviewVM
            {
                Question = question,
                Answers = answers,
                TraineeAnswers = traineeAnswers,
                Category = category,
                Count = count,
                Index = index,
                TestId = testId,
            };
        }

        public async Task<ReviewListVM> GetReviewListVM(string searchString, string sortOrder, string[] filters, int? page)
        {
            AddBearerToken();
            IEnumerable<CategoryDetailDto> filterList = await _client.CategoryAsync();
            IEnumerable<TraineeTestDto> tests = await _client.TraineeTestAllAsync();

            if (filters.Length > 0)
            {
                tests = tests
                    .Where(t => filters
                    .Any(x => x == t.SubCategory.Name || x == t.SubCategory.Category.Name));

            }

            if (!string.IsNullOrEmpty(searchString))
            {
                tests = tests
                    .Where(t => t.SubCategory.Name
                    .StartsWith(searchString, StringComparison.OrdinalIgnoreCase) || t.SubCategory.Category.Name
                    .StartsWith(searchString, StringComparison.OrdinalIgnoreCase));
            }

            switch (sortOrder)
            {
                case "category":
                    tests = tests.OrderBy(t => t.SubCategory.Name);
                    break;
                case "language":
                    tests = tests.OrderBy(t => t.SubCategory.Category.Name);
                    break;
                case "score":
                    tests = tests.OrderBy(t => t.Score);
                    break;
                case "date":
                    tests = tests.OrderBy(t => t.CreatedDate);
                    break;
            }

            var reviewList = new ReviewListVM
            {
                Tests = PaginatedList<TraineeTestDto>.Create(tests.ToList(), page ?? 1, 10),
                Filters = filterList
            };

            var subs = tests.Select(t => t.SubCategory).DistinctBy(c => c.Id);

            foreach(var category in subs)
            {
                int count = await _client.AnswerGETCountTotalAsync(category.Id);
                reviewList.AnswerCounts.Add(category.Id, count);
            }

            return reviewList;
        }
    }
}
