using MediatR;
using TraineeTracker.Application.DTOs.Trainer;

namespace TraineeTracker.Application.Features.Trainers.Requests.Queries
{
    public class GetTrainerListByCourseRequest : IRequest<List<TrainerDto>>
    {
        public int Id { get; set; }
    }
}
