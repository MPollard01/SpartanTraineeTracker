using TraineeTracker.MVC.Models;

namespace TraineeTracker.MVC.Contracts
{
    public interface IProfileService
    {
        Task<TraineeVM> GetTraineeProfile();
    }
}
