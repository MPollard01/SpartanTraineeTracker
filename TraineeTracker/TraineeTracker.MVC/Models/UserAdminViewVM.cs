using System.Collections;

namespace TraineeTracker.MVC.Models
{
    public class UserAdminViewVM
    {
        public ArrayList Users { get; set; }
        public RegisterTrainerVM RegisterTrainers { get; set; }
        public RegisterTraineeVM RegisterTrainees { get; set; }
    }
}
