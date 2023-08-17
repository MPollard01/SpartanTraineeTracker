using TraineeTracker.Domain;

namespace TraineeTracker.Application.Contracts.Persistence
{
    public interface ITraineeTestRepository : IRepository<TraineeTest>
    {
        Task<TraineeTest> GetTraineeTestWithAnswersById(int id);
        Task<TraineeTest> GetTraineeTestWithAnswersByLatestDate(string traineeId);
        Task<TraineeTest> GetTraineeTestWithCategoryByLatestDate(string traineeId);
        Task<int> GetTraineeTestIdByLatestDate(string traineeId);
        Task<List<TraineeTest>> GetTraineeTestsWithAnswers();
        Task<List<TraineeTest>> GetTraineeTestsWithAnswersByTraineeId(string traineeId);
        Task<List<TraineeTest>> GetTraineeTestsWithAnswersByTraineeIdAndCategory(string traineeId, string category);
    }
}
