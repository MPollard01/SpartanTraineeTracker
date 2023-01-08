using TraineeTracker.Domain;

namespace TraineeTracker.Application.Contracts.Persistence
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<Course> GetCourseByTitle(string title);
    }
}
