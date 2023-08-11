using MediatR;
using TraineeTracker.Application.DTOs.TraineeTest;

namespace TraineeTracker.Application.Features.TraineeTests.Requests.Queries
{
    public class GetTraineeTestDetailRequest : IRequest<TraineeTestDetailDto>
    {
        public int Id { get; set; }
    }
}
