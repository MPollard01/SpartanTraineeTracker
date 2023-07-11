using Microsoft.AspNetCore.Identity;
using TraineeTracker.Indentity.Models;

namespace TraineeTracker.Indentity
{
    public class SeedIdentity
    {
        public static async Task SeedIdentityData(TraineeTrackerIdentityDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roles = new List<IdentityRole>
                {
                    new IdentityRole
                    {
                        Id = "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                        Name = "Trainee",
                        NormalizedName = "TRAINEE"
                    },
                    new IdentityRole
                    {
                        Id = "cac43a7e-f7bb-4446-baaf-1add431ddbbf",
                        Name = "Trainer",
                        NormalizedName = "TRAINER"
                    },
                    new IdentityRole
                    {
                        Id = "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                        Name = "Administrator",
                        NormalizedName = "ADMINISTRATOR"
                    }
                };

                await context.Roles.AddRangeAsync(roles);
            }

            if (!context.UserRoles.Any())
            {
                var userRoles = new List<IdentityUserRole<string>>
                {
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
                };

                await context.UserRoles.AddRangeAsync(userRoles);
            }

            if (!context.Users.Any())
            {
                var hasher = new PasswordHasher<ApplicationUser>();

                var users = new List<ApplicationUser>
                {
                    new ApplicationUser
                     {
                         Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                         Email = "admin@localhost.com",
                         NormalizedEmail = "ADMIN@LOCALHOST.COM",
                         FirstName = "System",
                         LastName = "Admin",
                         UserName = "admin@localhost.com",
                         NormalizedUserName = "ADMIN@LOCALHOST.COM",
                         PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                         EmailConfirmed = true
                     },
                     new ApplicationUser
                     {
                         Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                         Email = "johndoe@sparta.com",
                         NormalizedEmail = "JOHNDOE@SPARTA.COM",
                         FirstName = "John",
                         LastName = "Doe",
                         UserName = "johndoe@sparta.com",
                         NormalizedUserName = "JOHNDOE@SPARTA.COM",
                         PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                         EmailConfirmed = true
                     },
                     new ApplicationUser
                     {
                         Id = "0c1518f6-e6bc-4568-b694-e50fb2a3eac1",
                         Email = "janedoe@sparta.com",
                         NormalizedEmail = "JANEDOE@SPARTA.COM",
                         FirstName = "Jane",
                         LastName = "Doe",
                         UserName = "janedoe@sparta.com",
                         NormalizedUserName = "JANEDOE@SPARTA.COM",
                         PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                         EmailConfirmed = true
                     },
                     new ApplicationUser
                     {
                         Id = "7e6adc8b-0a6e-4970-af0c-18f7fe18336d",
                         Email = "carlangle@sparta.com",
                         NormalizedEmail = "CARLANGLE@SPARTA.COM",
                         FirstName = "Carl",
                         LastName = "Angle",
                         UserName = "carlangle@sparta.com",
                         NormalizedUserName = "CARLANGLE@SPARTA.COM",
                         PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                         EmailConfirmed = true
                     },
                     new ApplicationUser
                     {
                         Id = "2cbdecbb-791e-45c0-93de-51abc9b71859",
                         Email = "kimsale@sparta.com",
                         NormalizedEmail = "KIMSALE@SPARTA.COM",
                         FirstName = "Kim",
                         LastName = "Sale",
                         UserName = "kimsale@sparta.com",
                         NormalizedUserName = "KIMSALE@SPARTA.COM",
                         PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                         EmailConfirmed = true
                     }
                };

                await context.Users.AddRangeAsync(users);
            }

            if (context.ChangeTracker.HasChanges())
                await context.SaveChangesAsync();
        }
    }
}
