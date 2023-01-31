using AutoMapper;
using Moq;
using Shouldly;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Trainee;
using TraineeTracker.Application.Features.Trainees.Handlers.Commands;
using TraineeTracker.Application.Features.Trainees.Requests.Commands;
using TraineeTracker.Application.Responses;
using TraineeTracker.Application.UnitTests.Mocks;

namespace TraineeTracker.Application.UnitTests.Trainees.Commands
{
    public class CreateTraineeCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly Mock<ITraineeRepository> _mockTrainee;
        private readonly CreateTraineeDto _createTrainee;

        public CreateTraineeCommandHandlerTests()
        {
            _mockTrainee = Mockup.Trainee.GetAll().Add();
            _mockUow = new MockUnitOfWorkRepository(_mockTrainee).SetRepos();
            _mapper = MapperConfig.Configure();

            _createTrainee = new CreateTraineeDto
            {
                Id = "1234",
                FirstName = "marko",
                LastName = "polo",
                Email = "mpolo@mail.com"
            };
        }

        [Fact]
        public async Task Handle_WhenCalled_AddsTraineeToRepository()
        {
            var handler = new CreateTraineeCommandHandler(_mockUow.Object, _mapper);
            var result = await handler.Handle(new CreateTraineeCommand { TraineeDto = _createTrainee }, CancellationToken.None);
            _mockUow.Verify(uow => uow.Save(), Times.Once());
            var trainees = await _mockUow.Object.TraineeRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeTrue();
            result.Message.ShouldBe("Creation Successfull");
            result.Errors.ShouldBeNull();
            trainees.Count.ShouldBe(3);
        }

        [Fact]
        public async Task Handle_GivenTraineeWithExistingId_ReturnsFailedResponse()
        {
            Mockup.And.Trainee(_mockTrainee).Exists(_createTrainee.Id, true);

            var handler = new CreateTraineeCommandHandler(_mockUow.Object, _mapper);
            var result = await handler.Handle(new CreateTraineeCommand 
                { TraineeDto = _createTrainee }, CancellationToken.None);
            var trainees = await _mockUow.Object.TraineeRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBe(false);
            trainees.Count.ShouldBe(2);
            result.Message.ShouldBe("Creation Failed");
        }

        [Fact]
        public async Task Handle_GivenTrainerWithNoId_ReturnsFailedResponse()
        {
            var handler = new CreateTraineeCommandHandler(_mockUow.Object, _mapper);
            var result = await handler.Handle(new CreateTraineeCommand 
                { TraineeDto = new CreateTraineeDto() }, CancellationToken.None);
            var trainees = await _mockUow.Object.TraineeRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBe(false);
            trainees.Count.ShouldBe(2);
            result.Message.ShouldBe("Creation Failed");
        }
    }
}
