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
    public class GetTraineeDetailRequestHandlerTests
    {
        private readonly IMapper _mapper;
        public static IEnumerable<object[]> testData = TraineeTestData.TestDataTrainees;

        public GetTraineeDetailRequestHandlerTests()
        {
            _mapper = MapperConfig.Configure();
        }

        [Theory]
        [MemberData(nameof(testData))]
        public async Task Handle_WhenCalled_ReturnsTrainer(Trainee expectedTrainee, string id)
        {
            Mock<ITraineeRepository> mockRepo = Mockup.Trainee.GetTraineeWithDetails(id, expectedTrainee);
     
            var handler = new GetTraineeDetailRequestHandler(mockRepo.Object, _mapper);
            var result = await handler.Handle(new GetTraineeDetailRequest { Id = id }, CancellationToken.None);
            var traineeDto = _mapper.Map<TraineeDetailDto>(expectedTrainee);

            result.ShouldBeOfType<TraineeDetailDto>();
            result.ShouldBeEquivalentTo(traineeDto);
        }

        [Fact]
        public async Task Handle_GivenAnIdThatDoesNotExist_ReturnsNull()
        {          
            Mock<ITraineeRepository> mockRepo = Mockup.Trainee.GetTraineeWithDetails("123", It.IsAny<Trainee>());
            var handler = new GetTraineeDetailRequestHandler(mockRepo.Object, _mapper);
            var result = await handler.Handle(new GetTraineeDetailRequest { Id = It.IsAny<string>() }, CancellationToken.None);

            result.ShouldBeNull();
        }
    }
}
