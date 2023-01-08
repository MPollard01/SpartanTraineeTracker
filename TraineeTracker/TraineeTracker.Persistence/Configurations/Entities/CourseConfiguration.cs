using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TraineeTracker.Domain;

namespace TraineeTracker.Persistence.Configurations.Entities
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasData(
                new Course { Id = 1, Title = "C# Developer"},
                new Course { Id = 2, Title = "C# SDET"},
                new Course { Id = 3, Title = "Java Developer"},
                new Course { Id = 4, Title = "Java SDET"}
            );
        }
    }
}
