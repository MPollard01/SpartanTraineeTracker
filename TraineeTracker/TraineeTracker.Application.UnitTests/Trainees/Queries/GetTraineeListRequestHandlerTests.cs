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
    public class GetTraineeListRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ITraineeRepository> _mockTraineeRepo;

        public GetTraineeListRequestHandlerTests()
        {
            _mockTraineeRepo = new Mock<ITraineeRepository>();
            _mapper = new MapperConfiguration(c => c
                .AddProfile<MappingProfile>())
                .CreateMapper();
        }

        [Fact]
        public async Task Handle_WhenCalled_ReturnsListOfTrainees()
        {
            _mockTraineeRepo.Setup(x => x.GetAll()).ReturnsAsync(TraineeTestData.trainees);
            var handler = new GetTraineeListRequestHandler(_mockTraineeRepo.Object, _mapper);
            var result = await handler.Handle(new GetTraineeListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<TraineeDto>>();
            result.Count.ShouldBe(2);
        }

        [Fact]
        public async Task Handle_GivenRepositoryIsEmpty_ReturnsEmptyList()
        {
            _mockTraineeRepo.Setup(x => x.GetAll()).ReturnsAsync(new List<Trainee>());
            var handler = new GetTraineeListRequestHandler(_mockTraineeRepo.Object, _mapper);
            var result = await handler.Handle(new GetTraineeListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<TraineeDto>>();
            result.Count.ShouldBe(0);
        }
    }
}
