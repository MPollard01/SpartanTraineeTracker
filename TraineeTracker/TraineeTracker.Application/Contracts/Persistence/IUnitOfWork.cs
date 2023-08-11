
namespace TraineeTracker.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ITrackerRepository TrackerRepository { get; }
        ITrainerRepository TrainerRepository { get; }
        ICourseRepository CourseRepository { get; }
        ITraineeRepository TraineeRepository { get; }
        ITrainerTraineeRepository TrainerTraineeRepository { get; }
        ITrainerCourseRepository TrainerCourseRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ISubCategoryRepository SubCategoryRepository { get; }
        IAnswerRepository AnswerRepository { get; }
        ITraineeTestRepository TraineeTestRepository { get; }
        ITraineeAnswerRepository TraineeAnswerRepository { get; }
        Task Save();
    }
}
