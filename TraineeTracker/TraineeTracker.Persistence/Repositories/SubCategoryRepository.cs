using Microsoft.EntityFrameworkCore;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Domain;

namespace TraineeTracker.Persistence.Repositories
{
    public class SubCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(TraineeTrackerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<SubCategory>> GetSubCategoriesByCategory(string category)
        {
            return await _dbContext.SubCategories
                .Where(sc => sc.Category.Name == category)
                .ToListAsync();
        }
    }
}
