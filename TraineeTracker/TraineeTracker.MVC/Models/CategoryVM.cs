using TraineeTracker.MVC.Services.Base;

namespace TraineeTracker.MVC.Models
{
    public class CategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CategoryListVM
    {
        public IEnumerable<SubCategoryDetailDto> SubCategories { get; set; }
        public IEnumerable<CategoryDetailDto> FilterList { get; set; }
        public CategoryVM Category { get; set; }
    }

    public class SubCategoryListVM
    {
        public ICollection<SubCategoryDto> Categories { get; set; }
        public CategoryVM Category { get; set; }
    }
}
