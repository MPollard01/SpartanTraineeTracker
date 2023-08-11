using MediatR;

namespace TraineeTracker.Application.Features.TraineeTests.Requests.Commands
{
    public class UpdateTraineeTestScoreCommand : IRequest<Unit>
    {
        public int TraineeTestId { get; set; }
        public int TraineeAnswerId { get; set; }
        public int Index { get; set; }
    }
}
