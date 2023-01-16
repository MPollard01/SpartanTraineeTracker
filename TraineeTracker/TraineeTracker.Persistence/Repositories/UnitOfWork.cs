using Microsoft.AspNetCore.Http;
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
