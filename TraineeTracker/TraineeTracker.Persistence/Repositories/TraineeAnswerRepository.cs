using Microsoft.EntityFrameworkCore;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Domain;

namespace TraineeTracker.Persistence.Repositories
{
    public class TraineeAnswerRepository : Repository<TraineeAnswer>, ITraineeAnswerRepository
    {
        public TraineeAnswerRepository(TraineeTrackerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<TraineeAnswer>> GetTraineeAnswersByTraineeTestId(int traineeTestId)
        {
            return await _dbContext.TraineeAnswers
                .Where(x => x.TraineeTestId == traineeTestId)
                .ToListAsync();
        }
    }
}
