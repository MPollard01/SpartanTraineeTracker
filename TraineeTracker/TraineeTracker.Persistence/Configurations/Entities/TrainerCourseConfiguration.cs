using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TraineeTracker.Domain;

namespace TraineeTracker.Persistence.Configurations.Entities
{
    public class TrainerCourseConfiguration : IEntityTypeConfiguration<TrainerCourse>
    {
        public void Configure(EntityTypeBuilder<TrainerCourse> builder)
        {
            builder.HasData(
                new TrainerCourse
                {
                    TrainerId = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                    CourseId = 1
                },
                new TrainerCourse
                {
                    TrainerId = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                    CourseId = 2
                },
                new TrainerCourse
                {
                    TrainerId = "0c1518f6-e6bc-4568-b694-e50fb2a3eac1",
                    CourseId = 1
                },
                new TrainerCourse
                {
                    TrainerId = "0c1518f6-e6bc-4568-b694-e50fb2a3eac1",
                    CourseId = 2
                }
            );
        }
    }
}
