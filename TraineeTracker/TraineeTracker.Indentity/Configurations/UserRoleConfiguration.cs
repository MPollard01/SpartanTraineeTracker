using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace TraineeTracker.Indentity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                // admin
                new IdentityUserRole<string>
                {
                    RoleId = "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                },
                // trainer
                new IdentityUserRole<string>
                {
                    RoleId = "cac43a7e-f7bb-4446-baaf-1add431ddbbf",
                    UserId = "9e224968-33e4-4652-b7b7-8574d048cdb9"
                },
                // trainer
                new IdentityUserRole<string>
                {
                    RoleId = "cac43a7e-f7bb-4446-baaf-1add431ddbbf",
                    UserId = "0c1518f6-e6bc-4568-b694-e50fb2a3eac1"
                },
                // trainee
                new IdentityUserRole<string>
                {
                    RoleId = "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                    UserId = "7e6adc8b-0a6e-4970-af0c-18f7fe18336d"
                },
                // trainee
                new IdentityUserRole<string>
                {
                    RoleId = "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                    UserId = "2cbdecbb-791e-45c0-93de-51abc9b71859"
                }
            );
        }
    }
}
