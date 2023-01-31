using AutoMapper;
using Moq;
using Shouldly;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Trainee;
using TraineeTracker.Application.Features.Trainees.Handlers.Queries;
using TraineeTracker.Application.Features.Trainees.Requests.Queries;
using TraineeTracker.Application.UnitTests.Mocks;
using TraineeTracker.Application.UnitTests.TestData;
using TraineeTracker.Domain;

namespace TraineeTracker.Application.UnitTests.Trainees.Queries
{
    public class GetTraineeListByCourseRequestHandlerTests
    {
        private readonly IMapper _mapper;

        public GetTraineeListByCourseRequestHandlerTests()
        {
            _mapper = MapperConfig.Configure();
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 1)]
        public async Task Handle_GivenCourseId_ReturnsTraineeList(int id, int index)
        {
            Mock<ITraineeRepository> mockRepo = Mockup.Trainee
                .GetTraineesByCourse(id, new List<Trainee> { TraineeTestData.trainees[index] });

            var handler = new GetTraineeListByCourseRequestHandler(_mapper, mockRepo.Object);
            var result = await handler.Handle(new GetTraineeListByCourseRequest { Id = id }, CancellationToken.None);

            result.ShouldBeOfType<List<TraineeDto>>();
            result.Count.ShouldBe(1);
        }

        [Fact]
        public async Task Handle_GivenNoTraineeHasCourseId_ReturnsEmptyList()
        {
            Mock<ITraineeRepository> mockRepo = Mockup.Trainee
                .GetTraineesByCourse(1, It.IsAny<List<Trainee>>());
           
            var handler = new GetTraineeListByCourseRequestHandler(_mapper, mockRepo.Object);
            var result = await handler.Handle(new GetTraineeListByCourseRequest { Id = 4 }, CancellationToken.None);

            result.ShouldBeOfType<List<TraineeDto>>();
            result.Count.ShouldBe(0);
        }
    }
}
