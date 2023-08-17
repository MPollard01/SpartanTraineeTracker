using TraineeTracker.Application.DTOs.SubCategory;

namespace TraineeTracker.Application.DTOs.TraineeTest
{
    public class TraineeTestWithCategoryDto
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public SubCategoryDto SubCategory { get; set; }
    }
}
