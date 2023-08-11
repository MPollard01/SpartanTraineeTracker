using MediatR;
using TraineeTracker.Application.DTOs.TraineeTest;
using TraineeTracker.Application.Responses;

namespace TraineeTracker.Application.Features.TraineeTests.Requests.Commands
{
    public class CreateTraineeTestCommand : IRequest<BaseCommandResponse>
    {
        public CreateTraineeTestDto TraineeTestDto { get; set; }
    }
}
