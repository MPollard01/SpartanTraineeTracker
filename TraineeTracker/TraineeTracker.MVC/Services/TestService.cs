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

        public async Task<List<CategoryDto>> GetCategories()
        {
            AddBearerToken();
            var categories = await _client.CategoryAsync();
            return categories.ToList();
        }

        public async Task<QuestionVM> GetQuestionWithCount(string category, int index)
        {
            AddBearerToken();
            var question = await _client.TestsAsync(category, index);
            int count = await _client.CountAsync(category);

            return new QuestionVM
            {
                Question = question,
                Count = count,
                Index = index
            };
        }

        public async Task<List<SubCategoryDto>> GetSubCategories(string category)
        {
            AddBearerToken();
            var subs = await _client.SubCategoryAsync(category);
            return subs.ToList();
        }
    }
}
