using System.ComponentModel.DataAnnotations.Schema;

namespace TraineeTracker.Domain
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public ICollection<Trainer> Trainers { get; set; }
    }
}
