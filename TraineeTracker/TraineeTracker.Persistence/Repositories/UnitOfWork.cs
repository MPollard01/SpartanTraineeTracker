﻿using Microsoft.AspNetCore.Http;
using TraineeTracker.Application.Constants;
using TraineeTracker.Application.Contracts.Persistence;

namespace TraineeTracker.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TraineeTrackerDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ITrackerRepository _trackerRepository;
        private ICourseRepository _courseRepository;
        private ITrainerRepository _trainerRepository;
        private ITraineeRepository _traineeRepository;
        private ITrainerTraineeRepository _traineeTraineeRepository;
        private ITrainerCourseRepository _trainerCourseRepository;
        private IQuestionRepository _questionRepository;
        private ICategoryRepository _categoryRepository;
        private ISubCategoryRepository _subCategoryRepository;
        private ITraineeTestRepository _traineeTestRepository;
        private ITraineeAnswerRepository _traineeAnswerRepository;
        private IAnswerRepository _answerRepository;

        public UnitOfWork(TraineeTrackerDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this._httpContextAccessor = httpContextAccessor;
        }

        public ITrackerRepository TrackerRepository =>
            _trackerRepository ??= new TrackerRepository(_context);
        public ICourseRepository CourseRepository =>
            _courseRepository ??= new CourseRepository(_context);
        public ITrainerRepository TrainerRepository =>
            _trainerRepository ??= new TrainerRepository(_context);
        public ITraineeRepository TraineeRepository =>
            _traineeRepository ??= new TraineeRepository(_context);
        public ITrainerTraineeRepository TrainerTraineeRepository =>
            _traineeTraineeRepository ??= new TrainerTraineeRepository(_context);
        public ITrainerCourseRepository TrainerCourseRepository =>
            _trainerCourseRepository ??= new TrainerCourseRepository(_context);
        public IQuestionRepository QuestionRepository =>
            _questionRepository ??= new QuestionRepository(_context);
        public ICategoryRepository CategoryRepository =>
            _categoryRepository ??= new CategoryRepository(_context);
        public ISubCategoryRepository SubCategoryRepository =>
            _subCategoryRepository ??= new SubCategoryRepository(_context);
        public ITraineeTestRepository TraineeTestRepository =>
            _traineeTestRepository ??= new TraineeTestRepository(_context);
        public ITraineeAnswerRepository TraineeAnswerRepository =>
            _traineeAnswerRepository ??= new TraineeAnswerRepository(_context);
        public IAnswerRepository AnswerRepository =>
            _answerRepository ??= new AnswerRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;

            await _context.SaveChangesAsync(username);
        }
    }
}
