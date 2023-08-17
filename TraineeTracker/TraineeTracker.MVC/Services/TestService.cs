using TraineeTracker.MVC.Contracts;
using TraineeTracker.MVC.Models;
using TraineeTracker.MVC.Services.Base;

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

        public async Task<CategoryListVM> GetCategories()
        {
            AddBearerToken();
            var categories = await _client.CategoryAsync();
            return new CategoryListVM { Categories = categories };
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

        public async Task<List<SubCategoryDto>> GetSubCategories(string category)
        {
            AddBearerToken();
            var subs = await _client.SubCategoryAsync(category);
            return subs.ToList();
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
    }
}
