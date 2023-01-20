using Microsoft.EntityFrameworkCore;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Domain;

namespace TraineeTracker.Persistence.Repositories
{
    public class TrackerRepository : Repository<Tracker>, ITrackerRepository
    {
        public TrackerRepository(TraineeTrackerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Tracker>> GetTrackersWithDetails()
        {
            return await _dbContext.Tracker
                .Include(t => t.Trainee)
                .ToListAsync();
        }

        public async Task<List<Tracker>> GetTrackersWithDetails(string userId)
        {
            return await _dbContext.Tracker
                .Where(t => t.TraineeId == userId)
                .Include(t => t.Trainee)
                .ToListAsync();
        }

        public async Task<Tracker> GetTrackerWithDetails(int id)
        {
            return await _dbContext.Tracker
                .Include(t => t.Trainee)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
