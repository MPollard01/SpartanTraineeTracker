namespace TraineeTracker.MVC.Models
{
    public class TraineeVM
    {
        public string Id { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public CourseVM Course { get; set; }
        public List<TraineeVM> Trainers { get; set; }
    }

    public class TraineeListVM
    {
        public string Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}
