using TraineeTracker.MVC.Models;
using TraineeTracker.MVC.Services.Base;
using TraineeTracker.MVC.Utils;

namespace TraineeTracker.MVC.Contracts
{
    public interface ITrackerService
    {
        Task<PaginatedList<TrackerListVM>> GetTrackers(string searchString, string sortOrder, string[] filter, int? pageNumber);
        Task<TrackerTraineeListVM> GetTraineeTrackers(string searchString, string sortOrder, string[] filter, int? pageNumber);
        Task<TrackerTraineeVM> GetTracker(int id);
        Task<Response<int>> CreateTracker(CreateTrackerVM trackerVM);
    }
}
