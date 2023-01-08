using Microsoft.EntityFrameworkCore;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Domain;

namespace TraineeTracker.Persistence.Repositories
{
    public class TraineeRepository : Repository<Trainee>, ITraineeRepository
    {
        public TraineeRepository(TraineeTrackerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Trainee>> GetTraineesWithDetails()
        {
            return await _dbContext.Trainees
                .Include(t => t.Course)
                .Include(t => t.Trainers)
                .ToListAsync();
        }

        public async Task<Trainee> GetTraineeWithDetails(string id)
        {
            return await _dbContext.Trainees
                .Where(t => t.Id == id)
                .Include(t => t.Course)
                .Include(t => t.Trainers)
                .FirstOrDefaultAsync();
        }
    }
}
