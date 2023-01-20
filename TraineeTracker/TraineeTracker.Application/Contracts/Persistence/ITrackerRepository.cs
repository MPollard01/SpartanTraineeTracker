using TraineeTracker.Domain;

namespace TraineeTracker.Application.Contracts.Persistence
{
    public interface ITrackerRepository : IRepository<Tracker>
    {
        Task<Tracker> GetTrackerWithDetails(int id);
        Task<Tracker> GetTrackerByDate(DateTime date, string id);
        Task<List<Tracker>> GetTrackersByDate(DateTime date);
        Task<List<Tracker>> GetTrackersWithDetails();
        Task<List<Tracker>> GetTrackersWithDetails(string userId);
    }
}
