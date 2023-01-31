using AutoMapper;
using Microsoft.AspNetCore.Http;
using Moq;
using Shouldly;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Tracker;
using TraineeTracker.Application.Features.Trackers.Handlers.Queries;
using TraineeTracker.Application.Features.Trackers.Requests.Queries;
using TraineeTracker.Application.UnitTests.Mocks;
using TraineeTracker.Application.UnitTests.TestData;
using TraineeTracker.Domain;

namespace TraineeTracker.Application.UnitTests.Trackers.Queries
{
    public class GetTrackerListByTrainerRequestHandlerTests
    {
        private readonly Mock<ITrackerRepository> _mockRepo;
        private readonly IMapper _mapper;
        private Mock<IHttpContextAccessor> _mockContextAccessor;

        public GetTrackerListByTrainerRequestHandlerTests()
        {
            _mockRepo = new Mock<ITrackerRepository>();
            _mapper = MapperConfig.Configure();
            _mockContextAccessor = MockHttpContextAccessor
                .GetHttpContext(TrainerTestData.trainers[0].Id, TrainerTestData.trainers[0].Email);
        }

        [Fact]
        public async Task Handle_WhenCalled_ReturnsTrackerList()
        {
            _mockRepo.Setup(x => x.GetTrackersByTrainer(TrainerTestData.trainers[0].Id))
                .ReturnsAsync(TrackerTestData.trackers);
            var handler = new GetTrackerListByTrainerRequestHandler(_mockRepo.Object, _mapper, _mockContextAccessor.Object);
            var result = await handler.Handle(new GetTrackerListByTrainerRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<TrackerListDto>>();
            result.Count.ShouldBe(2);
        }

        [Fact]
        public async Task Handle_GivenNoTrackersExist_ReturnsEmptyList()
        {
            _mockRepo.Setup(x => x.GetTrackersByTrainer(TrainerTestData.trainers[0].Id))
                .ReturnsAsync(new List<Tracker>());
            var handler = new GetTrackerListByTrainerRequestHandler(_mockRepo.Object, _mapper, _mockContextAccessor.Object);
            var result = await handler.Handle(new GetTrackerListByTrainerRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<TrackerListDto>>();
            result.Count.ShouldBe(0);
        }

        [Fact]
        public async Task Handle_GivenTrainerIdDoesNotExist_ReturnsEmptyList()
        {
            _mockContextAccessor.Setup(x => x.HttpContext).Returns(new DefaultHttpContext());
            _mockRepo.Setup(x => x.GetTrackersByTrainer(TrainerTestData.trainers[0].Id))
                .ReturnsAsync(TrackerTestData.trackers);
            var handler = new GetTrackerListByTrainerRequestHandler(_mockRepo.Object, _mapper, _mockContextAccessor.Object);
            var result = await handler.Handle(new GetTrackerListByTrainerRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<TrackerListDto>>();
            result.Count.ShouldBe(0);
        }
    }
}
