using MediatR;
using TraineeTracker.Application.DTOs.Trainer;

namespace TraineeTracker.Application.Features.Trainers.Requests.Queries
{
    public class GetTrainerListRequest : IRequest<List<TrainerDto>>
    {
       
    }
}
