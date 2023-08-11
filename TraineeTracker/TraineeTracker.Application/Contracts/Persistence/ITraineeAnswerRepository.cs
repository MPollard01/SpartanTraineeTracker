using TraineeTracker.Domain;

namespace TraineeTracker.Application.Contracts.Persistence
{
    public interface ITraineeAnswerRepository : IRepository<TraineeAnswer>
    {
        Task<List<TraineeAnswer>> GetTraineeAnswersByTraineeTestId(int traineeTestId);
    }
}
