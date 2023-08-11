namespace TraineeTracker.Domain
{
    public class TraineeAnswer
    {
        public int Id { get; set; }
        public string Answer { get; set; } = null!;
        public int TraineeTestId { get; set; }
        public TraineeTest TraineeTest { get; set; } = null!;
        public string TraineeId { get; set; } = null!;
    }
}
