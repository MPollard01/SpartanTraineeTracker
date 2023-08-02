using TraineeTracker.MVC.Models;
using TraineeTracker.MVC.Services.Base;

namespace TraineeTracker.MVC.Contracts
{
    public interface ITestService
    {
        Task<QuestionVM> GetQuestionWithCount(string category, int index);
        Task<List<CategoryDto>> GetCategories();
        Task<List<SubCategoryDto>> GetSubCategories(string category);
    }
}
