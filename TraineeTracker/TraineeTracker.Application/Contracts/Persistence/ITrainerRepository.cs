using TraineeTracker.Domain;

namespace TraineeTracker.Application.Contracts.Persistence
{
    public interface ITrainerRepository : IRepository<Trainer>
    {
        Task<Trainer> GetTrainerWithDetails(string id);
        Task<List<Trainer>> GetTrainersWithDetails();
    }
}
