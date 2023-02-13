using TraineeTracker.MVC.Services.Base;

namespace TraineeTracker.MVC.Models
{
    public class TrainerVM
    {
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public List<CourseDto> Courses { get; set; }
        public List<TraineeForTrainerDetailDto> Trainees { get; set; }
    }

    public class TrainerListVM : UserListVM
    {
        
    }

}
