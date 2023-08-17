using Microsoft.EntityFrameworkCore;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Domain;

namespace TraineeTracker.Persistence.Repositories
{
    public class TraineeTestRepository : Repository<TraineeTest>, ITraineeTestRepository
    {
        public TraineeTestRepository(TraineeTrackerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> GetTraineeTestIdByLatestDate(string traineeId)
        {
            return await _dbContext.TraineeTests
                .Where(t => t.TraineeId == traineeId)
                .OrderByDescending(t => t.CreatedDate)
                .Select(t => t.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<TraineeTest>> GetTraineeTestsWithAnswers()
        {
            return await _dbContext.TraineeTests
                .Include(x => x.Answers)
                .ToListAsync();
        }

        public async Task<List<TraineeTest>> GetTraineeTestsWithAnswersByTraineeId(string traineeId)
        {
            return await _dbContext.TraineeTests
                .Where(x => x.TraineeId == traineeId)
                .Include(x => x.Answers)
                .ToListAsync();
        }

        public async Task<List<TraineeTest>> GetTraineeTestsWithAnswersByTraineeIdAndCategory(string traineeId, string category)
        {
            return await _dbContext.TraineeTests
                .Where(x => x.TraineeId == traineeId && x.SubCategory.Name == category)
                .Include(x => x.Answers)
                .ToListAsync();
        }

        public async Task<TraineeTest> GetTraineeTestWithAnswersById(int id)
        {
            return await _dbContext.TraineeTests
                .Where(x => x.Id == id)
                .Include(x => x.Answers)
                .FirstOrDefaultAsync();
        }

        public async Task<TraineeTest> GetTraineeTestWithAnswersByLatestDate(string traineeId)
        {
            return await _dbContext.TraineeTests
                .Where(t => t.TraineeId == traineeId)
                .OrderByDescending(t => t.CreatedDate)
                .Include(t => t.Answers)
                .FirstOrDefaultAsync();
        }

        public async Task<TraineeTest> GetTraineeTestWithCategoryByLatestDate(string traineeId)
        {
            return await _dbContext.TraineeTests
                .Where(t => t.TraineeId == traineeId)
                .OrderByDescending(t => t.CreatedDate)
                .Include(t => t.SubCategory)
                .FirstOrDefaultAsync();
        }
    }
}
