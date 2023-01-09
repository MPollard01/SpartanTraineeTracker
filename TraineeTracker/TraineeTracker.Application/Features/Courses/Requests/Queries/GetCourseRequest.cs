using MediatR;
using TraineeTracker.Application.DTOs.Course;

namespace TraineeTracker.Application.Features.Courses.Requests.Queries
{
    public class GetCourseRequest : IRequest<CourseDto>
    {
        public int Id { get; set; }
    }
}
