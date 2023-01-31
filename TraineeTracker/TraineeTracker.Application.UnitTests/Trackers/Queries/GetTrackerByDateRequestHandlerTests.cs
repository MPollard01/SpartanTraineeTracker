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

namespace TraineeTracker.Application.UnitTests.Trackers.Queries
{
    public class GetTrackerByDateRequestHandlerTests
    {
        private readonly Mock<ITrackerRepository> _mockRepo;
        private readonly IMapper _mapper;
        private Mock<IHttpContextAccessor> _mockContextAccessor;
        public static IEnumerable<object[]> testData = TrackerTestData.TestDataTrackers;

        public GetTrackerByDateRequestHandlerTests()
        {
            _mockRepo = new Mock<ITrackerRepository>();
            _mapper = MapperConfig.Configure();
            _mockContextAccessor = MockHttpContextAccessor
                .GetHttpContext(TraineeTestData.trainees[0].Id, TraineeTestData.trainees[0].Email);
        }

        [Theory]
        [MemberData(nameof(testData))]
        public async Task Handle_WhenDateExists_ReturnsTracker(string id, DateTime date, int index, int expectedId)
        {
            _mockContextAccessor = MockHttpContextAccessor
                .GetHttpContext(id, "email");
            _mockRepo.Setup(x => x.GetTrackerByDate(date, id))
                .ReturnsAsync(TrackerTestData.trackers[index]);

            var handler = new GetTrackerByDateRequestHandler(_mapper, _mockContextAccessor.Object, _mockRepo.Object);
            var result = await handler.Handle(new GetTrackerByDateRequest { Date = date }, CancellationToken.None);

            result.ShouldBeOfType<TrackerDto>();
            result.Id.ShouldBe(expectedId);
            result.StartDate.ShouldBe(date);
        }

        [Fact]
        public async Task Handle_GivenAnIdThatDoesNotExist_ReturnsNull()
        {
            _mockRepo.Setup(x => x.GetTrackerByDate(DateTime.Now, It.IsAny<string>()))
                .ReturnsAsync(TrackerTestData.trackers[0]);

            var handler = new GetTrackerByDateRequestHandler(_mapper, _mockContextAccessor.Object, _mockRepo.Object);
            var result = await handler.Handle(new GetTrackerByDateRequest { Date = It.IsAny<DateTime>() }, CancellationToken.None);

            result.ShouldBeNull();
        }

        [Fact]
        public async Task Handle_GivenTraineeIdDoesNotExist_ReturnsNull()
        {
            _mockContextAccessor.Setup(x => x.HttpContext).Returns(new DefaultHttpContext());
            _mockRepo.Setup(x => x.GetTrackerByDate(It.IsAny<DateTime>(), "id"))
               .ReturnsAsync(TrackerTestData.trackers[0]);

            var handler = new GetTrackerByDateRequestHandler(_mapper, _mockContextAccessor.Object, _mockRepo.Object);
            var result = await handler.Handle(new GetTrackerByDateRequest { Date = It.IsAny<DateTime>() }, CancellationToken.None);

            result.ShouldBeNull();
        }
    }
}
