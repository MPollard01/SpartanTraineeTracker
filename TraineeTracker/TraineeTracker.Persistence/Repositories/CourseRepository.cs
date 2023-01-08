using Microsoft.EntityFrameworkCore;
using TraineeTracker.Application.Contracts.Persistence;
using TraineeTracker.Domain;

namespace TraineeTracker.Persistence.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(TraineeTrackerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Course> GetCourseByTitle(string title)
        {
            return await _dbContext.Courses
                .FirstOrDefaultAsync(c => c.Title == title);
        }
    }
}
