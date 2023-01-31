using Moq;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Application.UnitTests.TestData;
using TraineeTracker.Domain;

namespace TraineeTracker.Application.UnitTests.Mocks
{
    public class MockTraineeRepository
    {
        private readonly List<Trainee> _data;
        private readonly Mock<ITraineeRepository> _mockRepo;

        public MockTraineeRepository()
        {
            _data = TraineeTestData.trainees;
            _mockRepo = new Mock<ITraineeRepository>();
        }

        public MockTraineeRepository(Mock<ITraineeRepository> repo)
        {
            _data = TraineeTestData.trainees;
            _mockRepo = repo;
        }
        public MockTraineeRepository GetAll()
        {
            _mockRepo.Setup(x => x.GetAll()).ReturnsAsync(_data);
            return this;
        }

        public MockTraineeRepository Add()
        {
            _mockRepo.Setup(x => x.Add(It.IsAny<Trainee>()))
                .Callback<Trainee>(t => _data.Add(t));
            return this;
        }

        public MockTraineeRepository Exists(string id, bool result)
        {
            _mockRepo.Setup(x => x.Exists(id)).ReturnsAsync(result);
            return this;
        }

        public MockTraineeRepository GetTraineeWithDetails(string id, Trainee output)
        {
            _mockRepo.Setup(x => x.GetTraineeWithDetails(id)).ReturnsAsync(output);
            return this;
        }

        public MockTraineeRepository GetTraineesByCourse(int id, List<Trainee> trainees)
        {
            _mockRepo.Setup(x => x.GetTraineesByCourse(id)).ReturnsAsync(trainees);
            return this;
        }

        public Mock<ITraineeRepository> Mock()
        {
            return _mockRepo;
        }

        public static implicit operator Mock<ITraineeRepository>(MockTraineeRepository repo)
        {
            return repo.Mock();
        }
    }
}
