using AutoMapper;
using Moq;
using Shouldly;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Trainer;
using TraineeTracker.Application.Features.Trainers.Handlers.Commands;
using TraineeTracker.Application.Features.Trainers.Requests.Commands;
using TraineeTracker.Application.Profiles;
using TraineeTracker.Application.Responses;
using TraineeTracker.Application.UnitTests.TestData;
using TraineeTracker.Domain;

namespace TraineeTracker.Application.UnitTests.Trainers.Commands
{
    public class CreateTrainerCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        private readonly CreateTrainerDto _createTrainerDto;

        public CreateTrainerCommandHandlerTests()
        {
            _mockUow = new Mock<IUnitOfWork>();
            _mapper = new MapperConfiguration(c => c
                .AddProfile<MappingProfile>())
                .CreateMapper();

            _mockUow.Setup(uow => uow.TrainerRepository.Add(It.IsAny<Trainer>()))
                .ReturnsAsync((Trainer trainer) =>
                {
                    TrainerTestData.trainers.Add(trainer);
                    return trainer;
                });

            _mockUow.Setup(uow => uow.TrainerRepository.GetAll())
                .ReturnsAsync(TrainerTestData.trainers);

            _createTrainerDto = new CreateTrainerDto
            {
                Id = "123",
                FirstName = "marko",
                LastName = "polo",
                Email = "mpolo@mail.com"
            };
        }

        [Fact]
        public async Task Handle_WhenCalled_AddsTrainerToRepository()
        {
            var handle = new CreateTrainerCommandHandler(_mockUow.Object, _mapper);
            var result = await handle.Handle(new CreateTrainerCommand 
                { TrainerDto = _createTrainerDto }, CancellationToken.None);

            _mockUow.Verify(uow => uow.Save(), Times.Once());
            var trainers = await _mockUow.Object.TrainerRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBe(true);
            result.Message.ShouldBe("Creation Successfull");
            result.Errors.ShouldBeNull();
            trainers.Count.ShouldBe(3);
        }

        [Fact]
        public async Task Handle_GivenTrainerWithExistingId_ReturnsFailedResponse()
        {
            var handle = new CreateTrainerCommandHandler(_mockUow.Object, _mapper);
            var createTrainerDto = new CreateTrainerDto 
            { Id = "9e224968-33e4-4652-b7b7-8574d048cdb9" };

            _mockUow.Setup(uow => uow.TrainerRepository
                .Exists(createTrainerDto.Id)).ReturnsAsync(true);

            var result = await handle.Handle(new CreateTrainerCommand
            { TrainerDto = createTrainerDto }, CancellationToken.None);

            var trainers = await _mockUow.Object.TrainerRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBe(false);
            trainers.Count.ShouldBe(2);
            result.Message.ShouldBe("Creation Failed");
        }

        [Fact]
        public async Task Handle_GivenTrainerWithNoId_ReturnsFailedResponse()
        {
            var handle = new CreateTrainerCommandHandler(_mockUow.Object, _mapper);

            var result = await handle.Handle(new CreateTrainerCommand
            { TrainerDto = new CreateTrainerDto() }, CancellationToken.None);

            var trainers = await _mockUow.Object.TrainerRepository.GetAll();

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBe(false);
            trainers.Count.ShouldBe(2);
            result.Message.ShouldBe("Creation Failed");
        }
    }
}
