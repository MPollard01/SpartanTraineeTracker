using TraineeTracker.Domain;

namespace TraineeTracker.Application.Contracts.Persistence
{
    public interface ITrackerRepository : IRepository<Tracker>
    {
        Task<Tracker> GetTrackerWithDetails(int id);
        Task<List<Tracker>> GetTrackersWithDetails();
        Task<List<Tracker>> GetTrackersWithDetails(string userId);
    }
}
