using TraineeTracker.Application.DTOs.SubCategory;

namespace TraineeTracker.Application.DTOs.TraineeTest
{
    public class TraineeTestDto
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public DateTime CreatedDate { get; set; }
        public SubCategoryDetailDto SubCategory { get; set; }
    }
}
