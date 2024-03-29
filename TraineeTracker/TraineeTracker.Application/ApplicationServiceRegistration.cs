﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TraineeTracker.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection ConfigureApplictionServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
