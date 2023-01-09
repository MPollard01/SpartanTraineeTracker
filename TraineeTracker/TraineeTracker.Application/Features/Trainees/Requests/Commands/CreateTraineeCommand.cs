using MediatR;
using TraineeTracker.Application.DTOs.Trainee;
using TraineeTracker.Application.Responses;

namespace TraineeTracker.Application.Features.Trainees.Requests.Commands
{
    public class CreateTraineeCommand : IRequest<BaseCommandResponse>
    {
        public CreateTraineeDto TraineeDto { get; set; }
    }
}
