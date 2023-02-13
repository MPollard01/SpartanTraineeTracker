using TraineeTracker.MVC.Models;
using TraineeTracker.MVC.Services.Base;

namespace TraineeTracker.MVC.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> Authenticate(string email, string password);
        Task<string> Register(RegisterVM registration, string role);
        Task<ChangePasswordResponse> ChangePassword(ProfileVM profile);
        Task Logout();
    }
}
