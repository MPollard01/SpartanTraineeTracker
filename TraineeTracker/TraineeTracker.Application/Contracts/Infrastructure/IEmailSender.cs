using TraineeTracker.Application.Models;

namespace TraineeTracker.Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
