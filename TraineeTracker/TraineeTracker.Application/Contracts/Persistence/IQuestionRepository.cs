using TraineeTracker.Domain;

namespace TraineeTracker.Application.Contracts.Persistence
{
    public interface IQuestionRepository : IRepository<Question>
    {
        Task<Question> GetQuestionWithDetails(int id);
        Task<Question> GetQuestionByCategory(string category, int index);
        Task<List<Question>> GetQuestionsByCategory(string category);
        Task<List<Question>> GetQuestionsByType(string type);
        Task<int> GetQuestionCountByCategory(string category);
    }
}
