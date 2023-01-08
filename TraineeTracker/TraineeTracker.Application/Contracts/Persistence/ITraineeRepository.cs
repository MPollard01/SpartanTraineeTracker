using TraineeTracker.Domain;

namespace TraineeTracker.Application.Contracts.Persistence
{
    public interface ITraineeRepository : IRepository<Trainee>
    {
        Task<Trainee> GetTraineeWithDetails(string id);
        Task<List<Trainee>> GetTraineesWithDetails();
    }
}
