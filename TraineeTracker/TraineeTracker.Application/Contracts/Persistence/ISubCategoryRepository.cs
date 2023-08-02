using TraineeTracker.Domain;

namespace TraineeTracker.Application.Contracts.Persistence
{
    public interface ISubCategoryRepository : IRepository<SubCategory>
    {
        Task<List<SubCategory>> GetSubCategoriesByCategory(string category);
    }
}
