using Microsoft.EntityFrameworkCore;
using TraineeTracker.Domain;

namespace TraineeTracker.Persistence
{
    public class TraineeTrackerDbContext : AuditableDbContext
    {
        public TraineeTrackerDbContext(DbContextOptions<TraineeTrackerDbContext> options) : base(options)
        {
        }

        public DbSet<Tracker> Trackers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Trainer> Trainer { get; set; }
        public DbSet<TrainerTrainee> TrainerTrainees { get; set; }
        public DbSet<TrainerCourse> TrainerCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TraineeTrackerDbContext).Assembly);

            modelBuilder.Entity<TrainerTrainee>()
                .HasKey(tt => new { tt.TrainerId, tt.TraineeId });
            modelBuilder.Entity<TrainerCourse>()
                .HasKey(tc => new { tc.TrainerId, tc.CourseId });
        }
    }
}
