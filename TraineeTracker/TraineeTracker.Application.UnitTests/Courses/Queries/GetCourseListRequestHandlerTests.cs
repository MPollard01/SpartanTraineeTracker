using AutoMapper;
using Moq;
using Shouldly;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Course;
using TraineeTracker.Application.Features.Courses.Handlers.Queries;
using TraineeTracker.Application.Features.Courses.Requests.Queries;
using TraineeTracker.Application.UnitTests.TestData;
using TraineeTracker.Domain;

namespace TraineeTracker.Application.UnitTests.Courses.Queries
{
    public class GetCourseListRequestHandlerTests
    {
        private readonly Mock<ICourseRepository> _mockRepo;
        private readonly IMapper _mapper;
        public GetCourseListRequestHandlerTests()
        {
            _mockRepo = new Mock<ICourseRepository>();
            _mapper = MapperConfig.Configure();
        }

        [Fact]
        public async Task Handle_WhenCalled_ReturnsCourseList()
        {
            _mockRepo.Setup(x => x.GetAll()).ReturnsAsync(CourseTestData.courses);
            var handler = new GetCourseListRequestHandler(_mockRepo.Object, _mapper);
            var result = await handler.Handle(new GetCourseListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<CourseDto>>();
            result.Count.ShouldBe(4);
        }

        [Fact]
        public async Task Handle_WhenRepositoryIsEmpty_ReturnsEmptyList()
        {
            _mockRepo.Setup(x => x.GetAll()).ReturnsAsync(new List<Course>());
            var handler = new GetCourseListRequestHandler(_mockRepo.Object, _mapper);
            var result = await handler.Handle(new GetCourseListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<CourseDto>>();
            result.Count.ShouldBe(0);
            result.ShouldBeEmpty();
        }
    }
}
