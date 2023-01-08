using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TraineeTracker.Domain;

namespace TraineeTracker.Persistence.Configurations.Entities
{
    public class TrainerTraineeConfiguration : IEntityTypeConfiguration<TrainerTrainee>
    {
        public void Configure(EntityTypeBuilder<TrainerTrainee> builder)
        {
            builder.HasData(
                new TrainerTrainee
                {
                    TrainerId = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                    TraineeId = "7e6adc8b-0a6e-4970-af0c-18f7fe18336d"
                },
                new TrainerTrainee
                {
                    TrainerId = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                    TraineeId = "2cbdecbb-791e-45c0-93de-51abc9b71859"
                },
                new TrainerTrainee
                {
                    TrainerId = "0c1518f6-e6bc-4568-b694-e50fb2a3eac1",
                    TraineeId = "7e6adc8b-0a6e-4970-af0c-18f7fe18336d"
                },
                new TrainerTrainee
                {
                    TrainerId = "0c1518f6-e6bc-4568-b694-e50fb2a3eac1",
                    TraineeId = "2cbdecbb-791e-45c0-93de-51abc9b71859"
                }
            );
        }
    }
}
