using TraineeTracker.Application.DTOs.Course;
using TraineeTracker.Application.DTOs.Trainee;

namespace TraineeTracker.Application.DTOs.Trainer
{
    public class TrainerDetailDto : ITrainerDto
    {
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public List<CourseDto> Courses { get; set; }
        public List<TraineeDetailDto> Trainees { get; set; }
    }
}
