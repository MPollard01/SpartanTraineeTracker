using MediatR;
using TraineeTracker.Application.DTOs.TraineeTest;

namespace TraineeTracker.Application.Features.TraineeTests.Requests.Queries
{
    public class GetTraineeTestListRequest : IRequest<List<TraineeTestDto>>
    {
    }
}
