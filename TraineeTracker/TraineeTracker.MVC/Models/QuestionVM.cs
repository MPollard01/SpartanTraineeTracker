using TraineeTracker.MVC.Services.Base;

namespace TraineeTracker.MVC.Models
{
    public class QuestionVM
    {
        public QuestionDto Question { get; set; }
        public string Category { get; set; }
        public CreateAnswerVM Answer { get; set; }
        public int Count { get; set; }
        public int Index { get; set; }
        public int AnswerCount { get; set; }
    }
}
