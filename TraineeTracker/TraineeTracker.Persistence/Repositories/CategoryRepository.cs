using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Domain;

namespace TraineeTracker.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(TraineeTrackerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
