namespace TraineeTracker.MVC.Models
{
    public class UserAdminViewVM
    {
        public List<TrainerVM> Trainers { get; set; }
        public List<TraineeVM> Trainees { get; set; }
        public RegisterTrainerVM RegisterTrainers { get; set; }
        public RegisterTraineeVM RegisterTrainees { get; set; }
    }
}
