using TraineeTracker.MVC.Models;

namespace TraineeTracker.MVC.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> Authenticate(string email, string password);
        Task<string> Register(RegisterVM registration, string role);
        Task Logout();
    }
}
