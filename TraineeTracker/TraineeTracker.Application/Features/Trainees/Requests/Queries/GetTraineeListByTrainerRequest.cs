using MediatR;
using TraineeTracker.Application.DTOs.Trainee;

namespace TraineeTracker.Application.Features.Trainees.Requests.Queries
{
    public class GetTraineeListByTrainerRequest : IRequest<List<TraineeCourseDto>>
    {

    }
}
