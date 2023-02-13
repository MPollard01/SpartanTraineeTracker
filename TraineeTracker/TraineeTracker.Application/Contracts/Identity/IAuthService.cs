using TraineeTracker.Application.Models.Identity;

namespace TraineeTracker.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<ChangePasswordResponse> ChangePassword(ChangePasswordRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request, string role);
    }
}
