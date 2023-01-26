using AutoMapper;
using Moq;
using Shouldly;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Trainer;
using TraineeTracker.Application.Features.Trainers.Handlers.Queries;
using TraineeTracker.Application.Features.Trainers.Requests.Queries;
using TraineeTracker.Application.Profiles;
using TraineeTracker.Application.UnitTests.TestData;

namespace TraineeTracker.Application.UnitTests.Trainers.Queries
{
    public class GetTrainerListByCourseRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ITrainerRepository> _mockTrainerRepo;

        public GetTrainerListByCourseRequestHandlerTests()
        {
            _mockTrainerRepo = new Mock<ITrainerRepository>();
            _mapper = new MapperConfiguration(c => c
                .AddProfile<MappingProfile>())
                .CreateMapper();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task Handle_WhenCalled_ReturnsTrainers(int id)
        {
            _mockTrainerRepo.Setup(x => x.GetTrainersByCourse(id))
                .ReturnsAsync(TrainerTestData.trainers);
            var handler = new GetTrainerListByCourseRequestHandler(_mapper, _mockTrainerRepo.Object);

            var result = await handler.Handle(new GetTrainerListByCourseRequest { Id = id }, CancellationToken.None);

            result.ShouldBeOfType<List<TrainerDto>>();
            result.Count.ShouldBe(2);
        }

        [Fact]
        public async Task Handle_GivenIncorrectId_ReturnsEmptyList()
        {
            _mockTrainerRepo.Setup(x => x.GetTrainersByCourse(1))
                .ReturnsAsync(TrainerTestData.trainers);
            var handler = new GetTrainerListByCourseRequestHandler(_mapper, _mockTrainerRepo.Object);

            var result = await handler.Handle(new GetTrainerListByCourseRequest { Id = It.IsAny<int>() }, CancellationToken.None);

            result.ShouldBeOfType<List<TrainerDto>>();
            result.Count.ShouldBe(0);
        }
    }
}
