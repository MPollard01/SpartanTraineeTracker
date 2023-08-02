namespace TraineeTracker.Domain
{
    public class Question
    {
        public int Id { get; set; }
        public string Value { get; set; } = null!;
        public int CategoryId { get; set; }
        public SubCategory Category { get; set; } = null!;
        public ICollection<Option> Options { get; } = new List<Option>();
        public ICollection<Answer> Answers { get; } = new List<Answer>();
    }
}
