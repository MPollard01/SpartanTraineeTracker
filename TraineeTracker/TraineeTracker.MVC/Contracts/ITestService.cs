using TraineeTracker.MVC.Models;
using TraineeTracker.MVC.Services.Base;

namespace TraineeTracker.MVC.Contracts
{
    public interface ITestService
    {
        Task<Response<int>> CreateTest(int categoryId);
        Task<Response<int>> CreateAnswer(CreateAnswerVM answerVM, int testId, int q, int count);
        Task<int> GetLatestTraineeTestId();
        Task<QuestionVM> GetQuestionWithCount(string category, int index);
        Task<ReviewVM> GetReviewVM(int testId, int index, string category);
        Task<CategoryListVM> GetCategories();
        Task<List<SubCategoryDto>> GetSubCategories(string category);
        Task<ResultVM> GetResult();
    }
}
