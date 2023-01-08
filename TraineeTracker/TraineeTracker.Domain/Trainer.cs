
namespace TraineeTracker.Domain
{
    public class Trainer
    {
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public virtual ICollection<Course>? Courses { get; set; }
        public virtual ICollection<Trainee>? Trainees { get; set; }
    }
}
