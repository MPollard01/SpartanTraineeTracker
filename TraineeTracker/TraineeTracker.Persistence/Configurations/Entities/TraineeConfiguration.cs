using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TraineeTracker.Domain;

namespace TraineeTracker.Persistence.Configurations.Entities
{
    public class TraineeConfiguration : IEntityTypeConfiguration<Trainee>
    {
        public void Configure(EntityTypeBuilder<Trainee> builder)
        {
            builder.HasData(
                new Trainee
                {
                    Id = "7e6adc8b-0a6e-4970-af0c-18f7fe18336d",
                    Email = "carlangle@sparta.com",
                    FirstName = "Carl",
                    LastName = "Angle",
                    CourseId = 1,
                },
                new Trainee
                {
                    Id = "2cbdecbb-791e-45c0-93de-51abc9b71859",
                    Email = "kimsale@sparta.com",
                    FirstName = "Kim",
                    LastName = "Sale",
                    CourseId = 2
                }
            );
        }
    }
}
