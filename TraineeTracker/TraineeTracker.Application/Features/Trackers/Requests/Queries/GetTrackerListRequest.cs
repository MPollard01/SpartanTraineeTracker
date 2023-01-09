using MediatR;
using TraineeTracker.Application.DTOs.Tracker;

namespace TraineeTracker.Application.Features.Trackers.Requests.Queries
{
    public class GetTrackerListRequest : IRequest<List<TrackerListDto>>
    {
        public bool IsTraineeLoggedIn { get; set; }
    }
}
