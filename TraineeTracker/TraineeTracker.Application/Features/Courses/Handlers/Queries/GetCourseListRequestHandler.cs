using AutoMapper;
using MediatR;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Course;
using TraineeTracker.Application.Features.Courses.Requests.Queries;

namespace TraineeTracker.Application.Features.Courses.Handlers.Queries
{
    public class GetCourseListRequestHandler : IRequestHandler<GetCourseListRequest, List<CourseDto>>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public GetCourseListRequestHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<List<CourseDto>> Handle(GetCourseListRequest request, CancellationToken cancellationToken)
        {
            var courses = await _courseRepository.GetAll();
            return _mapper.Map<List<CourseDto>>(courses);
        }
    }
}
