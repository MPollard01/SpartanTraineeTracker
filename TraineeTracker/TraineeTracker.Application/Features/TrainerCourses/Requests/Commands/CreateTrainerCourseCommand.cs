using MediatR;
using TraineeTracker.Application.DTOs.TrainerCourse;
using TraineeTracker.Application.Responses;

namespace TraineeTracker.Application.Features.TrainerCourses.Requests.Commands
{
    public class CreateTrainerCourseCommand : IRequest<BaseCommandResponse>
    {
        public CreateTrainerCourseDto TrainerCourseDto { get; set; }
    }
}
