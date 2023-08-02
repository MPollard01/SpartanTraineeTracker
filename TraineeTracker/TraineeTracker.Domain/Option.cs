namespace TraineeTracker.Domain
{
    public class Option
    {
        public int Id { get; set; }
        public string Value { get; set; } = null!;
        public int? QuestionId { get; set; }
        public Question? Question { get; set; }
    }
}
