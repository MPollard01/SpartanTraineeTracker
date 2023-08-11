using Microsoft.EntityFrameworkCore;
using TraineeTracker.Domain;

namespace TraineeTracker.Persistence
{
    public class TraineeTrackerDbContext : AuditableDbContext
    {
        public TraineeTrackerDbContext(DbContextOptions<TraineeTrackerDbContext> options) 
            : base(options)
        {
           
        }

        public DbSet<Tracker> Tracker { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Trainee> Trainee { get; set; }
        public DbSet<Trainer> Trainer { get; set; }
        public DbSet<TrainerTrainee> TrainerTrainee { get; set; }
        public DbSet<TrainerCourse> TrainerCourse { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<TraineeTest> TraineeTests { get; set; }
        public DbSet<TraineeAnswer> TraineeAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TraineeTrackerDbContext).Assembly);
           
            modelBuilder.Entity<TrainerTrainee>()
                .HasKey(tt => new { tt.TrainerId, tt.TraineeId });
            modelBuilder.Entity<TrainerCourse>()
                .HasKey(tc => new { tc.TrainerId, tc.CourseId });

            modelBuilder.Entity<Trainer>()
                .HasMany(t => t.Trainees)
                .WithMany(t => t.Trainers)
                .UsingEntity<TrainerTrainee>();

            modelBuilder.Entity<Trainee>()
                .HasMany(t => t.Trainers)
                .WithMany(t => t.Trainees)
                .UsingEntity<TrainerTrainee>();

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Trainers)
                .WithMany(c => c.Courses)
                .UsingEntity<TrainerCourse>();

        }
    }
}
