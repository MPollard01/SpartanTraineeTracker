﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Persistence.Repositories;

namespace TraineeTracker.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TraineeTrackerDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("TraineeTrackerConnectionString")));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}