namespace TraineeTracker.Domain
{
    public class TraineeTest
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public string TraineeId { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; } = null!;
        public ICollection<TraineeAnswer> Answers { get; set; } = new List<TraineeAnswer>();
    }
}
