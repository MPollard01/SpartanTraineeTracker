

using Moq;
using TraineeTracker.Application.Contracts.Persistence;

namespace TraineeTracker.Application.UnitTests.Mocks
{
    public static class Mockup
    {
        public static MockTraineeRepository Trainee => new MockTraineeRepository();

        public static class And
        {
            public static MockTraineeRepository Trainee(Mock<ITraineeRepository> mock) 
                => new MockTraineeRepository(mock);
        }
    }
}
