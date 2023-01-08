
namespace TraineeTracker.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ITrackerRepository TrackerRepository { get; }
        ITrainerRepository TrainerRepository { get; }
        ICourseRepository CourseRepository { get; }
        ITraineeRepository TraineeRepository { get; }
        Task Save();
    }
}
