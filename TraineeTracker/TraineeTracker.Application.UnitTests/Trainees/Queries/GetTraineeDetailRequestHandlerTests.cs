using AutoMapper;
using Moq;
using Shouldly;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Trainee;
using TraineeTracker.Application.Features.Trainees.Handlers.Queries;
using TraineeTracker.Application.Features.Trainees.Requests.Queries;
using TraineeTracker.Application.Profiles;
using TraineeTracker.Application.UnitTests.TestData;
using TraineeTracker.Domain;

namespace TraineeTracker.Application.UnitTests.Trainees.Queries
{
    public class GetTraineeDetailRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ITraineeRepository> _mockTraineeRepo;
        public static IEnumerable<object[]> testData = TraineeTestData.TestDataTrainees;

        public GetTraineeDetailRequestHandlerTests()
        {
            _mockTraineeRepo = new Mock<ITraineeRepository>();
            _mapper = new MapperConfiguration(c => c
                .AddProfile<MappingProfile>())
                .CreateMapper();
        }

        [Theory]
        [MemberData(nameof(testData))]
        public async Task Handle_WhenCalled_ReturnsTrainer(Trainee expectedTrainee, string id)
        {
            _mockTraineeRepo.Setup(x => x.GetTraineeWithDetails(id)).ReturnsAsync(expectedTrainee);
            var handler = new GetTraineeDetailRequestHandler(_mockTraineeRepo.Object, _mapper);
            var result = await handler.Handle(new GetTraineeDetailRequest { Id = id }, CancellationToken.None);
            var traineeDto = _mapper.Map<TraineeDetailDto>(expectedTrainee);

            result.ShouldBeOfType<TraineeDetailDto>();
            result.ShouldBeEquivalentTo(traineeDto);
        }

        [Fact]
        public async Task Handle_GivenAnIdThatDoesNotExist_ReturnsNull()
        {
            _mockTraineeRepo.Setup(x => x
                .GetTraineeWithDetails("7e6adc8b-0a6e-4970-af0c-18f7fe18336d"))
                .ReturnsAsync(TraineeTestData.trainees[0]);

            var handler = new GetTraineeDetailRequestHandler(_mockTraineeRepo.Object, _mapper);
            var result = await handler.Handle(new GetTraineeDetailRequest { Id = It.IsAny<string>() }, CancellationToken.None);

            result.ShouldBeNull();
        }
    }
}
