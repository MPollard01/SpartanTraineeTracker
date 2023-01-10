using TraineeTracker.MVC.Models;
using TraineeTracker.MVC.Services.Base;

namespace TraineeTracker.MVC.Contracts
{
    public interface ITraineeService
    {
        Task<Response<int>> CreateTrainee(RegisterTraineeVM traineeVM);
        Task<List<TraineeVM>> GetTrainees();
    }
}
