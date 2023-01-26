using AutoMapper;
using Moq;
using Shouldly;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Trainer;
using TraineeTracker.Application.Features.Trainers.Handlers.Queries;
using TraineeTracker.Application.Features.Trainers.Requests.Queries;
using TraineeTracker.Application.Profiles;
using TraineeTracker.Application.UnitTests.TestData;
using TraineeTracker.Domain;

namespace TraineeTracker.Application.UnitTests.Trainers.Queries
{
    public class GetTrainerDetailRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ITrainerRepository> _mockTrainerRepo;
        public static IEnumerable<object[]> testData = TrainerTestData.TestTrainerData;

        public GetTrainerDetailRequestHandlerTests()
        {
            _mockTrainerRepo = new Mock<ITrainerRepository>();
            
            _mapper = new MapperConfiguration(c => c
                .AddProfile<MappingProfile>())
                .CreateMapper();
        }

        [Theory]
        [MemberData(nameof(testData))]
        public async Task Handle_WhenCalled_ReturnsTrainerWithDetails(Trainer expectedTrainer, string id)
        {
            _mockTrainerRepo.Setup(x => x.GetTrainerWithDetails(id)).ReturnsAsync(expectedTrainer);
            var handle = new GetTrainerDetailRequestHandler(_mockTrainerRepo.Object, _mapper);
            var result = await handle.Handle(new GetTrainerDetailRequest { Id = id }, CancellationToken.None);

            var trainerDto = _mapper.Map<TrainerDetailDto>(expectedTrainer);

            result.ShouldBeOfType<TrainerDetailDto>();
            result.ShouldBeEquivalentTo(trainerDto);
            result.Id.ShouldBe(id);
            result.FirstName.ShouldBe(expectedTrainer.FirstName);
            result.LastName.ShouldBe(expectedTrainer.LastName);
            result.Email.ShouldBe(expectedTrainer.Email);
        }

        [Fact]
        public async Task Handle_GivenAnIdThatDoesNotExist_ReturnsNull()
        {
            _mockTrainerRepo.Setup(x => x
                .GetTrainerWithDetails("9e224968-33e4-4652-b7b7-8574d048cdb9"))
                .ReturnsAsync(TrainerTestData.trainers[0]);

            var handle = new GetTrainerDetailRequestHandler(_mockTrainerRepo.Object, _mapper);
            var result = await handle.Handle(new GetTrainerDetailRequest { Id = It.IsAny<string>() }, CancellationToken.None);

            result.ShouldBeNull();
        }
    }
}
