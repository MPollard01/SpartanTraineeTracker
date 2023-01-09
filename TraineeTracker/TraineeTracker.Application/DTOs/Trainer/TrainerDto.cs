using TraineeTracker.Application.DTOs.TrainerCourse;
using TraineeTracker.Application.DTOs.TrainerTrainee;

namespace TraineeTracker.Application.DTOs.Trainer
{
    public class TrainerDto : ITrainerDto
    {
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public List<TrainerCourseDto> Courses { get; set; }
        public List<TrainerTraineeDto> Trainees { get; set; }
    }
}
