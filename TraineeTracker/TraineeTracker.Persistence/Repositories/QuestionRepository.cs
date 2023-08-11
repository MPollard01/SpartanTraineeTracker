using Microsoft.EntityFrameworkCore;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Domain;

namespace TraineeTracker.Persistence.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        public QuestionRepository(TraineeTrackerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Question> GetQuestionByCategory(string category, int index)
        {
            return await _dbContext.Questions
               .Where(q => q.Category.Name == category)
               .Include(q => q.Options)
               .Skip(index - 1)
               .FirstOrDefaultAsync();
        }

        public async Task<Question> GetQuestionByCategoryId(int categoryId, int index)
        {
            return await _dbContext.Questions
               .Where(q => q.CategoryId == categoryId)
               .Skip(index - 1)
               .FirstOrDefaultAsync();
        }

        public async Task<int> GetQuestionCountByCategory(string category)
        {
            return await _dbContext.Questions
               .Where(q => q.Category.Name == category)
               .CountAsync();
        }

        public async Task<List<Question>> GetQuestionsByCategory(string category)
        {
            return await _dbContext.Questions          
                .Where(q => q.Category.Name == category)
                .Include(q => q.Options)
                .ToListAsync();
        }

        public async Task<List<Question>> GetQuestionsByType(string type)
        {
            return await _dbContext.Questions
                .Where(q => q.Category.Category.Name == type)
                .Include(q => q.Options)
                .ToListAsync();
        }

        public async Task<Question> GetQuestionWithDetails(int id)
        {
            return await _dbContext.Questions
                .Where(q => q.Id == id)
                .Include(q => q.Options)
                .Include(q => q.Answers)
                .FirstOrDefaultAsync();
        }
    }
}
