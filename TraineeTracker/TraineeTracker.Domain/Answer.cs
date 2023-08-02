namespace TraineeTracker.Domain
{
    public class Answer
    {
        public int Id { get; set; }
        public string Value { get; set; } = null!;
        public string? Description { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;
    }
}
