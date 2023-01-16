using MediatR;
using TraineeTracker.Application.DTOs.Trainee;

namespace TraineeTracker.Application.Features.Trainees.Requests.Queries
{
    public class GetTraineeListByCourseRequest : IRequest<List<TraineeDto>>
    {
        public int Id { get; set; }
    }
}
