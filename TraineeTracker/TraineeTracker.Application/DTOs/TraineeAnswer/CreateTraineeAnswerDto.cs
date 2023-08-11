namespace TraineeTracker.Application.DTOs.TraineeAnswer
{
    public class CreateTraineeAnswerDto
    {
        public string Answer { get; set; } = null!;
        public int TraineeTestId { get; set; }
    }
}
