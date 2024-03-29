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
           
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITrackerRepository, TrackerRepository>();
            services.AddScoped<ITraineeRepository, TraineeRepository>();
            services.AddScoped<ITrainerRepository, TrainerRepository>();
            services.AddScoped<ITrainerTraineeRepository, TrainerTraineeRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ITrainerCourseRepository, TrainerCourseRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<ITraineeTestRepository, TraineeTestRepository>();
            services.AddScoped<ITraineeAnswerRepository, TraineeAnswerRepository>();

            return services;
        }
    }
}
