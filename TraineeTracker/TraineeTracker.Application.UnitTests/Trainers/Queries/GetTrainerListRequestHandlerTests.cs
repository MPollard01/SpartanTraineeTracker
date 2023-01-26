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
    public class GetTrainerListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ITrainerRepository> _mockTrainerRepo;

        public GetTrainerListRequestHandlerTests()
        {
            _mockTrainerRepo = new Mock<ITrainerRepository>();
            _mapper = new MapperConfiguration(c => c
                .AddProfile<MappingProfile>())
                .CreateMapper();
        }

        [Fact]
        public async Task Handle_WhenCalled_ReturnsListOfTrainers()
        {
            _mockTrainerRepo.Setup(x => x.GetAll()).ReturnsAsync(TrainerTestData.trainers);
            var handler = new GetTrainerListRequestHandler(_mockTrainerRepo.Object, _mapper);

            var result = await handler.Handle(new GetTrainerListRequest(), CancellationToken.None);
            var trainerDto = _mapper.Map<List<TrainerDto>>(TrainerTestData.trainers);

            result.ShouldBeOfType<List<TrainerDto>>();
            result.Count.ShouldBe(2);
            result.ShouldBeEquivalentTo(trainerDto);
        }

        [Fact]
        public async Task Handle_WhenRepositoryIsEmpty_ReturnsEmptyList()
        {
            _mockTrainerRepo.Setup(x => x.GetAll()).ReturnsAsync(new List<Trainer>());
            var handler = new GetTrainerListRequestHandler(_mockTrainerRepo.Object, _mapper);

            var result = await handler.Handle(new GetTrainerListRequest(), CancellationToken.None);

            result.Count.ShouldBe(0);
            result.ShouldBeEmpty();
        }
    }
}
