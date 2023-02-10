using MediatR;
using TraineeTracker.Application.DTOs.Tracker;

namespace TraineeTracker.Application.Features.Trackers.Requests.Queries
{
    public class GetTrackerListByTraineeIdRequest : IRequest<List<TrackerDto>>
    {
        public string Id { get; set; }
    }
}
