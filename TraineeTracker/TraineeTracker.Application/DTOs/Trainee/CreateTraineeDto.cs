using TraineeTracker.Application.DTOs.Trainer;

namespace TraineeTracker.Application.DTOs.Trainee
{
    public class CreateTraineeDto : ITraineeDto
    {
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int CourseId { get; set; }
        public List<TrainerDto> Trainers { get; set; }
    }
}
