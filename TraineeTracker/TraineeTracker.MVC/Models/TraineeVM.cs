using TraineeTracker.MVC.Services.Base;
using TraineeTracker.MVC.Utils;

namespace TraineeTracker.MVC.Models
{
    public class TraineeVM
    {
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public CourseDto Course { get; set; }
        public List<TrainerForTraineeDetailDto> Trainers { get; set; }
    }

    public class TraineeAdminViewVM
    {
        public TraineeVM Trainee { get; set; }
        public int[] ConsultantSkillCount { get; set; }
        public int[] TechSkillCount { get; set; }
    }

    public class TraineesVM
    {
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public CourseVM Course { get; set; }
    }

    public class TrainerViewTraineesVM
    {
        public PaginatedList<TraineesVM> Trainees { get; set; }
        public List<string> Courses { get; set; }
    }

    public class TraineeListVM : UserListVM
    {
      
    }
}
