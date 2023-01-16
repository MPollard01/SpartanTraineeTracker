using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Domain;

namespace TraineeTracker.Persistence.Repositories
{
    public class TrainerCourseRepository : Repository<TrainerCourse>, ITrainerCourseRepository
    {
        public TrainerCourseRepository(TraineeTrackerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
