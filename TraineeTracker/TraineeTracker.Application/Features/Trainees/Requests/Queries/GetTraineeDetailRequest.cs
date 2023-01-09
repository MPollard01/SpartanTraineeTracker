using MediatR;
using TraineeTracker.Application.DTOs.Trainee;

namespace TraineeTracker.Application.Features.Trainees.Requests.Queries
{
    public class GetTraineeDetailRequest : IRequest<TraineeDto>
    {
        public string Id { get; set; }
    }
}
