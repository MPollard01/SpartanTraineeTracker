﻿using TraineeTracker.Domain;

namespace TraineeTracker.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithSubCategories();
    }
}
