
namespace TraineeTracker.Domain
{
    public class TrainerCourse
    {
        public string TrainerId { get; set; }
        public int CourseId { get; set; }
        public virtual Trainer Trainer { get; set; }
        public virtual Course Course { get; set; }
    }
}
