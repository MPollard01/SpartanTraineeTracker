using AutoMapper;
using MediatR;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Course;
using TraineeTracker.Application.Features.Courses.Requests.Queries;

namespace TraineeTracker.Application.Features.Courses.Handlers.Queries
{
    public class GetCourseRequestHandler : IRequestHandler<GetCourseRequest, CourseDto>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public GetCourseRequestHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<CourseDto> Handle(GetCourseRequest request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.Get(request.Id);
            return _mapper.Map<CourseDto>(course);
        }
    }
}
