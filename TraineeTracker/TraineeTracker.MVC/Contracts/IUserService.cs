using TraineeTracker.MVC.Models;

namespace TraineeTracker.MVC.Contracts
{
    public interface IUserService
    {
        Task<UserAdminViewVM> GetUserAdminList();
    }
}
