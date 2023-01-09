using MediatR;
using TraineeTracker.Application.DTOs.Tracker;

namespace TraineeTracker.Application.Features.Trackers.Requests.Queries
{
    public class GetTrackerDetailRequest : IRequest<TrackerDto>
    {
        public int Id { get; set; }
    }
}
