using TraineeTracker.Domain;
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
                        TraineeTestId = testId
                    };

                    var apiResponse = await _client.TraineeAnswerAsync(answerDto);

                    if (apiResponse.Success)
                    {
                        response.Success = true;
                        response.Message = apiResponse.Message;
                        
                        if(answers.Count() <= count)
                        {
                            // update score
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
            return await _client.TraineeTestGETLatestTestIdAsync();
        }
    }
}
