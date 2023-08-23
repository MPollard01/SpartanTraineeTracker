using TraineeTracker.MVC.Services.Base;
using TraineeTracker.MVC.Utils;

namespace TraineeTracker.MVC.Models
{
    public class ReviewVM
    {
        public QuestionDto Question { get; set; }
        public ICollection<AnswerDto> Answers { get; set; }
        public ICollection<TraineeAnswerDto> TraineeAnswers { get; set; }
        public string Category { get; set; }
        public int Count { get; set; }
        public int Index { get; set; }
        public int TestId { get; set; }
    }

    public class ReviewListVM
    {
        public PaginatedList<TraineeTestDto> Tests { get; set; }
        public IEnumerable<CategoryDetailDto> Filters { get; set; }
        public Dictionary<int, int> AnswerCounts { get; set; } = new Dictionary<int, int>();
    }
}
