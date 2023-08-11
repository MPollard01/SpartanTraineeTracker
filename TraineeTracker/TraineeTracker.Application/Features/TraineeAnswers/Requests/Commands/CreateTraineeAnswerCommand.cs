using MediatR;
using TraineeTracker.Application.DTOs.TraineeAnswer;
using TraineeTracker.Application.Responses;

namespace TraineeTracker.Application.Features.TraineeAnswers.Requests.Commands
{
    public class CreateTraineeAnswerCommand : IRequest<BaseCommandResponse>
    {
        public CreateTraineeAnswerDto TraineeDto { get; set; }
    }
}
