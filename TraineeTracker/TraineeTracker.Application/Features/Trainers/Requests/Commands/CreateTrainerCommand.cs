using MediatR;
using TraineeTracker.Application.DTOs.Trainer;
using TraineeTracker.Application.Responses;

namespace TraineeTracker.Application.Features.Trainers.Requests.Commands
{
    public class CreateTrainerCommand : IRequest<BaseCommandResponse>
    {
        public CreateTrainerDto TrainerDto { get; set; }
    }
}
