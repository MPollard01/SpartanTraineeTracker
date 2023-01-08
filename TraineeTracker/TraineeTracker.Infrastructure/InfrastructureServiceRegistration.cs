using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TraineeTracker.Application.Contracts.Infrastructure;
using TraineeTracker.Application.Models;
using TraineeTracker.Infrastructure.Mail;

namespace TraineeTracker.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();

            return services;
        }
    }
}
