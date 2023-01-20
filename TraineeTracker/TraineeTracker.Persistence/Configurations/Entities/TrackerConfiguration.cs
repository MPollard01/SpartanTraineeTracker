using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TraineeTracker.Domain;

namespace TraineeTracker.Persistence.Configurations.Entities
{
    public class TrackerConfiguration : IEntityTypeConfiguration<Tracker>
    {
        public void Configure(EntityTypeBuilder<Tracker> builder)
        {
            builder.HasData(
                new Tracker
                {
                    Id = 1,
                    Start = "Studying every day",
                    Stop = "Making silly mistakes",
                    Continue = "Learning C#",
                    StartDate = new DateTime(2022, 10, 12),
                    CreatedDate = new DateTime(2022, 10, 12),
                    TechnicalSkill = "Skilled",
                    ConsultantSkill = "Partially Skilled",
                    TraineeId = "7e6adc8b-0a6e-4970-af0c-18f7fe18336d",
                    CreatedBy = "Carl Angle"
                }
            );
        }
    }
}
