using MediatR;
using TraineeTracker.Application.DTOs.TrainerTrainee;
using TraineeTracker.Application.Responses;

namespace TraineeTracker.Application.Features.TrainerTrainees.Requests.Commands
{
    public class CreateTrainerTraineeCommand : IRequest<BaseCommandResponse>
    {
        public CreateTrainerTraineeDto TrainerTraineeDto { get; set; }
    }
}
