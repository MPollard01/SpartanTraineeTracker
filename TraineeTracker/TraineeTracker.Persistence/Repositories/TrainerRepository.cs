using Microsoft.EntityFrameworkCore;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Domain;

namespace TraineeTracker.Persistence.Repositories
{
    public class TrainerRepository : Repository<Trainer>, ITrainerRepository
    {
        public TrainerRepository(TraineeTrackerDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<List<Trainer>> GetTrainersByCourse(int courseId)
        {
            return await _dbContext.Trainer
                .Where(t => t.Courses.Any(t => courseId == t.Id))
                .ToListAsync();
        }

        public async Task<List<Trainer>> GetTrainersWithDetails()
        {
            return await _dbContext.Trainer
                .Include(t => t.Trainees)              
                .Include(t => t.Courses)             
                .ToListAsync();
        }

        public async Task<Trainer> GetTrainerWithDetails(string id)
        {
            return await _dbContext.Trainer
                .Where(t => t.Id == id)
                .Include(t => t.Trainees)
                .ThenInclude(t => t.Trainers)
                .Include(t => t.Courses)
                .FirstOrDefaultAsync();
        }
    }
}
