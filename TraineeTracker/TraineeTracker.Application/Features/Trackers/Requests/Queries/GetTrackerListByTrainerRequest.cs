using MediatR;
using TraineeTracker.Application.DTOs.Tracker;

namespace TraineeTracker.Application.Features.Trackers.Requests.Queries
{
    public class GetTrackerListByTrainerRequest : IRequest<List<TrackerListDto>>
    {

    }
}
