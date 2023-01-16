using System.ComponentModel.DataAnnotations.Schema;

namespace TraineeTracker.Domain
{
    public class Trainee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public ICollection<Trainer> Trainers { get; set; }
    }
}
