using AutoMapper;
using Moq;
using Shouldly;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Course;
using TraineeTracker.Application.Features.Courses.Handlers.Commands;
using TraineeTracker.Application.Features.Courses.Requests.Commands;
using TraineeTracker.Application.Responses;
using TraineeTracker.Application.UnitTests.TestData;
using TraineeTracker.Domain;

namespace TraineeTracker.Application.UnitTests.Courses.Commands
{
    public class CreateCourseCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly IMapper _mapper;
        private readonly CreateCourseDto _createCourseDto;

        public CreateCourseCommandHandlerTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _mapper = MapperConfig.Configure();

            _mockUow.Setup(x => x.CourseRepository.Add(It.IsAny<Course>()))
                .ReturnsAsync((Course c) => 
                {
                    CourseTestData.courses.Add(c);
                    return c;
                });
            _mockUow.Setup(x => x.CourseRepository.GetAll())
                .ReturnsAsync(CourseTestData.courses);

            _createCourseDto = new CreateCourseDto { Title = "title" };
        }

        [Fact]
        public async Task Handle_WhenCalled_AddsCourseToRepository()
        {
            var handler = new CreateCourseCommandHandler(_mockUow.Object, _mapper);
            var result = await handler.Handle(new CreateCourseCommand { CourseDto = _createCourseDto }, CancellationToken.None);
            var courses = await _mockUow.Object.CourseRepository.GetAll();
            _mockUow.Verify(uow => uow.Save(), Times.Once());

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBe(true);
            result.Message.ShouldBe("Creation Successfull");
            result.Errors.ShouldBeNull();
            courses.Count.ShouldBe(5);
        }

        [Fact]
        public async Task Handle_GivenCourseTitleIsLessThan3Letters_ReturnsFailedResponse()
        {
            var handler = new CreateCourseCommandHandler(_mockUow.Object, _mapper);
            _createCourseDto.Title = "fe";
            var result = await handler.Handle(new CreateCourseCommand { CourseDto = _createCourseDto }, CancellationToken.None);
            var courses = await _mockUow.Object.CourseRepository.GetAll();
            _mockUow.Verify(uow => uow.Save(), Times.Never());

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBe(false);
            result.Message.ShouldBe("Creation Failed");
            result.Errors.ShouldNotBeEmpty();
            courses.Count.ShouldBe(4);
        }
    }
}
