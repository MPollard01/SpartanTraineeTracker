using TraineeTracker.MVC.Utils;

namespace TraineeTracker.MVC.Models
{
    public class UserAdminViewVM
    {
        public PaginatedList<UserListVM> Users { get; set; }
        public RegisterTrainerVM RegisterTrainers { get; set; }
        public RegisterTraineeVM RegisterTrainees { get; set; }
    }

    public class UserListVM
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
