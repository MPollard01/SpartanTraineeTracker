using System.ComponentModel.DataAnnotations.Schema;

namespace TraineeTracker.Domain
{
    public class Trainer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public ICollection<Course> Courses { get; set; }
        public ICollection<Trainee> Trainees { get; set; }
    }
}
