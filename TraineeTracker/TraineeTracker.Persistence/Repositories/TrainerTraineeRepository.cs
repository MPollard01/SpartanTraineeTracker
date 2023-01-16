using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Domain;

namespace TraineeTracker.Persistence.Repositories
{
    public class TrainerTraineeRepository : Repository<TrainerTrainee>, ITrainerTraineeRepository
    {
        public TrainerTraineeRepository(TraineeTrackerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
