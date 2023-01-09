using MediatR;
using TraineeTracker.Application.DTOs.Tracker;
using TraineeTracker.Application.Responses;

namespace TraineeTracker.Application.Features.Trackers.Requests.Commands
{
    public class CreateTrackerCommand : IRequest<BaseCommandResponse>
    {
        public CreateTrackerDto TrackerDto { get; set; }
    }
}
