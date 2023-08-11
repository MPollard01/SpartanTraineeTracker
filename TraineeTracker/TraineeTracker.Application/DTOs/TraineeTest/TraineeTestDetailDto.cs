using TraineeTracker.Application.DTOs.TraineeAnswer;

namespace TraineeTracker.Application.DTOs.TraineeTest
{
    public class TraineeTestDetailDto
    {
        public int Score { get; set; }
        public string TraineeId { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public List<TraineeAnswerDto> Answers { get; set; }
    }
}
