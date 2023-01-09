using MediatR;
using TraineeTracker.Application.DTOs.Course;
using TraineeTracker.Application.Responses;

namespace TraineeTracker.Application.Features.Courses.Requests.Commands
{
    public class CreateCourseCommand : IRequest<BaseCommandResponse>
    {
        public CreateCourseDto CourseDto { get; set; }
    }
}
