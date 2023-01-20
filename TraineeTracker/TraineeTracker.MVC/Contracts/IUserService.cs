using TraineeTracker.MVC.Models;

namespace TraineeTracker.MVC.Contracts
{
    public interface IUserService
    {
        Task<UserAdminViewVM> GetUserAdminList(string searchString, string sortOrder, string[] filter, int? pageNumber);
    }
}
