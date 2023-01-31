using Moq;
using TraineeTracker.Application.Contracts.Persistence;

namespace TraineeTracker.Application.UnitTests.Mocks
{
    public class MockUnitOfWorkRepository
    {
        private readonly Mock<IUnitOfWork> _mockUow;
        private Mock[] _mocks;
        public MockUnitOfWorkRepository(params Mock[] mocks)
        {
            _mockUow = new Mock<IUnitOfWork>();
            _mocks = mocks;
        }
        public Mock<IUnitOfWork> SetRepos()
        {
            foreach (var mock in _mocks)
            {
                var type = mock.GetType().GetGenericArguments()[0].Name;
                switch (type)
                {
                    case nameof(ITraineeRepository):
                        _mockUow.Setup(x => x.TraineeRepository)
                            .Returns((ITraineeRepository)mock.Object);
                        break;
                }
            }

            return _mockUow;
        }
    }
}
