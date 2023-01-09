using MediatR;
using TraineeTracker.Application.DTOs.Course;

namespace TraineeTracker.Application.Features.Courses.Requests.Queries
{
    public class GetCourseListRequest : IRequest<List<CourseDto>>
    {
    }
}
