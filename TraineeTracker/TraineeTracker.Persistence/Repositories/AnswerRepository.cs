using Microsoft.EntityFrameworkCore;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Domain;

namespace TraineeTracker.Persistence.Repositories
{
    public class AnswerRepository : Repository<Answer>, IAnswerRepository
    {
        public AnswerRepository(TraineeTrackerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> GetAnswerCountByQuestionId(int questionId)
        {
            return await _dbContext.Answers
                .Where(a => a.QuestionId == questionId)
                .CountAsync();
        }

        public async Task<int> GetAnswerCountByCategoryId(int categoryId)
        {
            return await _dbContext.Answers
                .Where(a => a.Question.CategoryId == categoryId)
                .CountAsync();
        }

        public async Task<List<Answer>> GetAnswersByCategoryId(int categoryId)
        {
            return await _dbContext.Answers
                .Where(a => a.Question.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<List<Answer>> GetAnswersByQuestionId(int questionId)
        {
            return await _dbContext.Answers
                .Where(a => a.QuestionId == questionId)
                .ToListAsync();
        }

        public async Task<bool> HasAnswerByQuestionId(int questionId, string answer)
        {
            return await _dbContext.Answers
                .Where(a => a.QuestionId == questionId)
                .AnyAsync(a => a.Value == answer);
        }
    }
}
