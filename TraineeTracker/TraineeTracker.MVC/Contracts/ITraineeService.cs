using TraineeTracker.MVC.Models;
using TraineeTracker.MVC.Services.Base;

namespace TraineeTracker.MVC.Contracts
{
    public interface ITraineeService
    {
        Task<Response<int>> CreateTrainee(RegisterTraineeVM traineeVM);
        Task<List<TraineeListVM>> GetTrainees();
        Task<List<TraineesVM>> GetTraineesByTrainer(string searchString, string sortOrder, string[] filters, int? pageNumber);
    }
}
