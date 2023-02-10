using TraineeTracker.MVC.Models;

namespace TraineeTracker.MVC.Contracts
{
    public interface IHomeService
    {
        Task<AdminHomeVM> GetAdminHome();
        Task<TrainerHomeVM> GetTrainerHome();
        Task<TraineeHomeVM> GetTraineeHome();
    }
}
