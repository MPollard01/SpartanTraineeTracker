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
    public class GetCourseRequestHandlerTests
    {
        private readonly Mock<ICourseRepository> _mockRepo;
        private readonly IMapper _mapper;

        public GetCourseRequestHandlerTests()
        {
            _mockRepo = new Mock<ICourseRepository>();
            _mapper = MapperConfig.Configure();
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        public async Task Handle_WhenCalled_ReturnsCourse(int id, int index)
        {
            var course = CourseTestData.courses[index];
            _mockRepo.Setup(x => x.Get(id)).ReturnsAsync(course);
            var handler = new GetCourseRequestHandler(_mockRepo.Object, _mapper);
            var result = await handler.Handle(new GetCourseRequest { Id = id }, CancellationToken.None);

            result.ShouldBeOfType<CourseDto>();
            result.Id.ShouldBe(id);
            result.Title.ShouldBe(course.Title);
        }

        [Fact]
        public async Task Handle_GivenAnIdThatDoesNotExist_ReturnsNull()
        {
            _mockRepo.Setup(x => x.Get(8)).ReturnsAsync(It.IsAny<Course>());
            var handler = new GetCourseRequestHandler(_mockRepo.Object, _mapper);
            var result = await handler.Handle(new GetCourseRequest { Id = It.IsAny<int>() }, CancellationToken.None);

            result.ShouldBeNull();
        }
    }
}
