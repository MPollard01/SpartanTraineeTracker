using TraineeTracker.Application.DTOs.Course;

namespace TraineeTracker.Application.DTOs.Trainee
{
    public class TraineeCourseDto : ITraineeDto
    {
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public CourseDto Course { get; set; }
    }
}
