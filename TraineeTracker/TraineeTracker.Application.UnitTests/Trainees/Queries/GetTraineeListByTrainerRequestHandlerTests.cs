using AutoMapper;
using Microsoft.AspNetCore.Http;
using Moq;
using Shouldly;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.DTOs.Trainee;
using TraineeTracker.Application.Features.Trainees.Handlers.Queries;
using TraineeTracker.Application.Features.Trainees.Requests.Queries;
using TraineeTracker.Application.UnitTests.Mocks;
using TraineeTracker.Application.UnitTests.TestData;
using TraineeTracker.Domain;

namespace TraineeTracker.Application.UnitTests.Trainees.Queries
{
    public class GetTraineeListByTrainerRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ITraineeRepository> _mockTraineeRepo;
        private Mock<IHttpContextAccessor> _mockContextAccessor;

        public GetTraineeListByTrainerRequestHandlerTests()
        {
            _mockTraineeRepo = new Mock<ITraineeRepository>();
            _mapper = MapperConfig.Configure();
            _mockContextAccessor = MockHttpContextAccessor
                .GetHttpContext(TrainerTestData.trainers[0].Id, TrainerTestData.trainers[0].Email);
        }

        [Fact]
        public async Task Handle_WhenCalled_ReturnsTraineeList()
        {
            _mockTraineeRepo.Setup(x => x.GetTraineesWithCourse(TrainerTestData.trainers[0].Id))
                .ReturnsAsync(TraineeTestData.trainees);

            var handler = new GetTraineeListByTrainerRequestHandler
                (_mapper, _mockTraineeRepo.Object, _mockContextAccessor.Object);
            var result = await handler.Handle(new GetTraineeListByTrainerRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<TraineeCourseDto>>();
            result.Count.ShouldBe(2);
        }

        [Fact]
        public async Task Handle_GivenTrainerHasNoTrainees_ReturnsEmptyList()
        {
            _mockTraineeRepo.Setup(x => x.GetTraineesWithCourse(TrainerTestData.trainers[0].Id))
                .ReturnsAsync(new List<Trainee>());

            var handler = new GetTraineeListByTrainerRequestHandler
                (_mapper, _mockTraineeRepo.Object, _mockContextAccessor.Object);
            var result = await handler.Handle(new GetTraineeListByTrainerRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<TraineeCourseDto>>();
            result.Count.ShouldBe(0);
        }

        [Fact]
        public async Task Handle_GivenTrainerIsLoggedOut_ReturnsEmptyList()
        {
            _mockTraineeRepo.Setup(x => x.GetTraineesWithCourse(TrainerTestData.trainers[0].Id))
                .ReturnsAsync(TraineeTestData.trainees);
            _mockContextAccessor.Setup(x => x.HttpContext).Returns(new DefaultHttpContext());

            var handler = new GetTraineeListByTrainerRequestHandler
                (_mapper, _mockTraineeRepo.Object, _mockContextAccessor.Object);
            var result = await handler.Handle(new GetTraineeListByTrainerRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<TraineeCourseDto>>();
            result.Count.ShouldBe(0);
        }
    }
}
