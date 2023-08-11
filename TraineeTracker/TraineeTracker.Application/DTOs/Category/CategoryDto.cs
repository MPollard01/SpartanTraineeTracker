using TraineeTracker.Application.DTOs.SubCategory;

namespace TraineeTracker.Application.DTOs.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<SubCategoryDto> SubCategories { get; set; }
    }
}
