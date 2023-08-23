using TraineeTracker.MVC.Models;
using TraineeTracker.MVC.Services.Base;
using TraineeTracker.MVC.Utils;

namespace TraineeTracker.MVC.Contracts
{
    public interface ITestService
    {
        Task<Response<int>> CreateTest(int categoryId);
        Task<Response<int>> CreateAnswer(CreateAnswerVM answerVM, int testId, int q, int count);
        Task<int> GetLatestTraineeTestId();
        Task<QuestionVM> GetQuestionWithCount(string category, int index);
        Task<ReviewVM> GetReviewVM(int testId, int index, string category);
        Task<ReviewListVM> GetReviewListVM(string searchString, string sortOrder, string[] filters, int? page);
        Task<CategoryListVM> GetCategories(string searchString, string sortOrder, string[] filters);
        Task<SubCategoryListVM> GetSubCategories(string category);
        Task<ResultVM> GetResult();
    }
}
