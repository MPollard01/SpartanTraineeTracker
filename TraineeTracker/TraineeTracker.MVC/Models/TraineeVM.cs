using TraineeTracker.MVC.Services.Base;

namespace TraineeTracker.MVC.Models
{
    public class TraineeVM
    {
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public CourseDto Course { get; set; }
        public List<TrainerDto> Trainers { get; set; }
    }

    public class TraineesVM
    {
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public CourseVM Course { get; set; }
    }

    public class TraineeListVM : UserListVM
    {
      
    }
}
