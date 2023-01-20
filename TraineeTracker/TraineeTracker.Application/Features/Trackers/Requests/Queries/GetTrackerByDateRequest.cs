using MediatR;
using TraineeTracker.Application.DTOs.Tracker;

namespace TraineeTracker.Application.Features.Trackers.Requests.Queries
{
    public class GetTrackerByDateRequest : IRequest<TrackerDto>
    {
        public DateTime Date { get; set; }
    }
}
