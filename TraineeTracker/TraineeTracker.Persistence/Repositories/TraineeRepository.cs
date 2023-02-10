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

        public async Task<List<Trainee>> GetTraineesByCourse(int courseId)
        {
            return await _dbContext.Trainee
                .Where(t => t.CourseId == courseId)
                .ToListAsync();
        }

        public async Task<List<Trainee>> GetTraineesWithCourse(string trainerId)
        {
            return await _dbContext.Trainer
                .Where(t => t.Id == trainerId)
                .SelectMany(t => t.Trainees)
                .Include(t => t.Course)
                .ToListAsync();
        }

        public async Task<List<Trainee>> GetTraineesWithDetails()
        {
            return await _dbContext.Trainee
                .Include(t => t.Trainers)               
                .Include(t => t.Course)
                .ToListAsync();
        }

        public async Task<Trainee> GetTraineeWithDetails(string id)
        {
            return await _dbContext.Trainee
                .Where(t => t.Id == id)
                .Include(t => t.Course)
                .Include(t => t.Trainers)
                .ThenInclude(t => t.Trainees)
                .Include(t => t.Trainers)
                .ThenInclude(t => t.Courses)
                .FirstOrDefaultAsync();
        }
    }
}
