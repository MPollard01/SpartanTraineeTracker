using AutoMapper;
using Microsoft.AspNetCore.Http;
using Moq;
using Shouldly;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Tracker;
using TraineeTracker.Application.Features.Trackers.Handlers.Commands;
using TraineeTracker.Application.Features.Trackers.Requests.Commands;
using TraineeTracker.Application.Responses;
using TraineeTracker.Application.UnitTests.Mocks;
using TraineeTracker.Application.UnitTests.TestData;
using TraineeTracker.Domain;

namespace TraineeTracker.Application.UnitTests.Trackers.Commands
{
    public class CreateTrackerCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly IMapper _mapper;
        private Mock<IHttpContextAccessor> _mockContextAccessor;
        private CreateTrackerDto _createTrackerDto;
        public CreateTrackerCommandHandlerTests()
        {
            _mockUow = new Mock<IUnitOfWork>();          
            _mockUow.Setup(x => x.TrackerRepository.GetAll())
                .ReturnsAsync(TrackerTestData.trackers);
            _mockUow.Setup(x => x.TrackerRepository.Add(It.IsAny<Tracker>()))
                .ReturnsAsync((Tracker t) =>
                {
                    TrackerTestData.trackers.Add(t);
                    return t;
                });

            _mapper = MapperConfig.Configure();
            _mockContextAccessor = MockHttpContextAccessor
                .GetHttpContext(TrainerTestData.trainers[0].Id, TrainerTestData.trainers[0].Email);

            _createTrackerDto = new CreateTrackerDto
            {
                StartDate = DateTime.Now,
                Start = "start",
                Stop = "stop",
                ConsultantSkill = "Skilled",
                TechnicalSkill = "Skilled",
                Continue = "continue"
            };
        }

        [Fact]
        public async Task Handle_WhenCalled_AddsTrackerToRepository()
        {         
            var handler = new CreateTrackerCommandHandler(_mockUow.Object, _mapper, _mockContextAccessor.Object);
            var result = await handler.Handle(new CreateTrackerCommand { TrackerDto = _createTrackerDto }, CancellationToken.None);

            _mockUow.Verify(uow => uow.Save(), Times.Once());
            var trackers = await _mockUow.Object.TrackerRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBe(true);
            result.Message.ShouldBe("Creation Successfull");
            result.Errors.ShouldBeNull();
            trackers.Count.ShouldBe(3);
        }

        [Fact]
        public async Task Handle_GivenTrackerWithStartOfLessThan3Characters_ReturnsFailedResponse()
        {
            var handler = new CreateTrackerCommandHandler(_mockUow.Object, _mapper, _mockContextAccessor.Object);
            _createTrackerDto.Start = "ab";
            var result = await handler.Handle(new CreateTrackerCommand { TrackerDto = _createTrackerDto }, CancellationToken.None);
            var trackers = await _mockUow.Object.TrackerRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBe(false);
            result.Message.ShouldBe("Creation Failed");
            result.Errors.ShouldNotBeEmpty();
            trackers.Count.ShouldBe(2);
        }

        
    }
}
