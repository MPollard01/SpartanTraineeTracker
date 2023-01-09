

namespace TraineeTracker.Domain
{
    public class TraineeTrainer
    {
        public string TraineeId { get; set; }
        public string TrainerId { get; set; }
        public virtual Trainer Trainer { get; set; }
        public virtual Trainee Trainee { get; set; }
    }
}
