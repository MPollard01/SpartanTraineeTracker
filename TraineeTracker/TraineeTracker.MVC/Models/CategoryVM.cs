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
        public ICollection<CategoryDto> Categories { get; set; }
        public CategoryVM Category { get; set; }
    }
}
