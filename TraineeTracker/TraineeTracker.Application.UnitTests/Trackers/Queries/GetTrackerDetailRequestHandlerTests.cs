using AutoMapper;
using Moq;
using Shouldly;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Tracker;
using TraineeTracker.Application.Features.Trackers.Handlers.Queries;
using TraineeTracker.Application.Features.Trackers.Requests.Queries;
using TraineeTracker.Application.UnitTests.TestData;

namespace TraineeTracker.Application.UnitTests.Trackers.Queries
{
    public class GetTrackerDetailRequestHandlerTests
    {
        private readonly Mock<ITrackerRepository> _mockRepo;
        private readonly IMapper _mapper;

        public GetTrackerDetailRequestHandlerTests()
        {
            _mockRepo = new Mock<ITrackerRepository>();
            _mapper = MapperConfig.Configure();
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 1)]
        public async Task Handle_WhenCalled_ReturnsTracker(int id, int index)
        {
            _mockRepo.Setup(x => x.GetTrackerWithDetails(id))
                .ReturnsAsync(TrackerTestData.trackers[index]);

            var handler = new GetTrackerDetailRequestHandler(_mockRepo.Object, _mapper);
            var result = await handler.Handle(new GetTrackerDetailRequest { Id = id }, CancellationToken.None);

            result.ShouldBeOfType<TrackerDto>();
            result.Id.ShouldBe(id);
        }

        [Fact]
        public async Task Handle_GivenAnIdThatDoesNotExist_ReturnsNull()
        {
            _mockRepo.Setup(x => x.GetTrackerWithDetails(1))
                .ReturnsAsync(TrackerTestData.trackers[0]);

            var handler = new GetTrackerDetailRequestHandler(_mockRepo.Object, _mapper);
            var result = await handler.Handle(new GetTrackerDetailRequest { Id = 3 }, CancellationToken.None);

            result.ShouldBeNull();
        }
    }
}
