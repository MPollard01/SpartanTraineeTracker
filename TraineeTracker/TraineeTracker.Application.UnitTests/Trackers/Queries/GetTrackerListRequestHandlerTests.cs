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
    public class GetTrackerListRequestHandlerTests
    {
        private readonly Mock<ITrackerRepository> _mockRepo;
        private readonly IMapper _mapper;
        private Mock<IHttpContextAccessor> _mockContextAccessor;

        public GetTrackerListRequestHandlerTests()
        {
            _mockRepo = new Mock<ITrackerRepository>();
            _mapper = MapperConfig.Configure();
            _mockContextAccessor = MockHttpContextAccessor
                .GetHttpContext(TraineeTestData.trainees[0].Id, TraineeTestData.trainees[0].Email);
        }

        [Fact]
        public async Task Handle_WhenLoggedIn_ReturnsTrackerList()
        {
            _mockRepo.Setup(x => x.GetTrackersWithDetails(TraineeTestData.trainees[0].Id))
                .ReturnsAsync(new List<Tracker> { TrackerTestData.trackers[0] });
            var handler = new GetTrackerListRequestHandler(_mockRepo.Object, _mapper, _mockContextAccessor.Object);
            var result = await handler.Handle(new GetTrackerListRequest { IsTraineeLoggedIn = true }, CancellationToken.None);

            result.ShouldBeOfType<List<TrackerListDto>>();
            result.Count.ShouldBe(1);
        }

        [Fact]
        public async Task Handle_WhenLoggedOut_ReturnsTrackerList()
        {
            _mockRepo.Setup(x => x.GetTrackersWithDetails())
                .ReturnsAsync(TrackerTestData.trackers);
            var handler = new GetTrackerListRequestHandler(_mockRepo.Object, _mapper, _mockContextAccessor.Object);
            var result = await handler.Handle(new GetTrackerListRequest { IsTraineeLoggedIn = false }, CancellationToken.None);

            result.ShouldBeOfType<List<TrackerListDto>>();
            result.Count.ShouldBe(2);
        }

        [Fact]
        public async Task Handle_WhenLoggedOut_GivenNoTrackers_ReturnsEmptyList()
        {
            _mockRepo.Setup(x => x.GetTrackersWithDetails()).ReturnsAsync(new List<Tracker>());
            var handler = new GetTrackerListRequestHandler(_mockRepo.Object, _mapper, _mockContextAccessor.Object);
            var result = await handler.Handle(new GetTrackerListRequest { IsTraineeLoggedIn = false }, CancellationToken.None);

            result.ShouldBeOfType<List<TrackerListDto>>();
            result.Count.ShouldBe(0);
        }

        [Fact]
        public async Task Handle_WhenLoggedIn_GivenNoTrackers_ReturnsEmptyList()
        {
            _mockRepo.Setup(x => x.GetTrackersWithDetails(TraineeTestData.trainees[0].Id))
                .ReturnsAsync(new List<Tracker>());
            var handler = new GetTrackerListRequestHandler(_mockRepo.Object, _mapper, _mockContextAccessor.Object);
            var result = await handler.Handle(new GetTrackerListRequest { IsTraineeLoggedIn = true }, CancellationToken.None);

            result.ShouldBeOfType<List<TrackerListDto>>();
            result.Count.ShouldBe(0);
        }

        [Fact]
        public async Task Handle_GivenTraineeIdDoesNotExist_ReturnsEmptyList()
        {
            _mockContextAccessor.Setup(x => x.HttpContext).Returns(new DefaultHttpContext());
            _mockRepo.Setup(x => x.GetTrackersWithDetails(TraineeTestData.trainees[1].Id))
                .ReturnsAsync(new List<Tracker> { TrackerTestData.trackers[1] });

            var handler = new GetTrackerListRequestHandler(_mockRepo.Object, _mapper, _mockContextAccessor.Object);
            var result = await handler.Handle(new GetTrackerListRequest { IsTraineeLoggedIn = true }, CancellationToken.None);

            result.ShouldBeOfType<List<TrackerListDto>>();
            result.Count.ShouldBe(0);
        }
    }
}
