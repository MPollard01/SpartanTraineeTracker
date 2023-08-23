using TraineeTracker.Application.DTOs.Category;

namespace TraineeTracker.Application.DTOs.SubCategory
{
    public class SubCategoryDetailDto 
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public CategoryDto Category { get; set; }
    }
}
