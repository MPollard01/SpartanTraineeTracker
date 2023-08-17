using TraineeTracker.Domain;

namespace TraineeTracker.Application.Contracts.Persistence
{
    public interface IAnswerRepository : IRepository<Answer>
    {
        Task<List<Answer>> GetAnswersByQuestionId(int questionId);
        Task<List<Answer>> GetAnswersByCategoryId(int categoryId);
        Task<int> GetAnswerCountByQuestionId(int questionId);
        Task<int> GetAnswerCountByCategoryId(int categoryId);
        Task<bool> HasAnswerByQuestionId(int questionId, string answer);
    }
}
