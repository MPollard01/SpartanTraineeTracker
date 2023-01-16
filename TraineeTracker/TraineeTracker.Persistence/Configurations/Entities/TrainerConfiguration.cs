using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TraineeTracker.Domain;

namespace TraineeTracker.Persistence.Configurations.Entities
{
    public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.HasData(
                new Trainer
                {
                    Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                    Email = "johndoe@sparta.com",
                    FirstName = "John",
                    LastName = "Doe",              
                },
                new Trainer
                {
                    Id = "0c1518f6-e6bc-4568-b694-e50fb2a3eac1",
                    Email = "janedoe@sparta.com",
                    FirstName = "Jane",
                    LastName = "Doe",                   
                }
            );
        }
    }
}
