using TraineeTracker.MVC.Models;
using TraineeTracker.MVC.Services.Base;

namespace TraineeTracker.MVC.Contracts
{
    public interface ITrainerService
    {
        Task<Response<int>> CreateTrainer(RegisterTrainerVM trainerVM);
    }
}
