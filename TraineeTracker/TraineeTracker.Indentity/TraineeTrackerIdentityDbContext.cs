using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TraineeTracker.Indentity.Configurations;
using TraineeTracker.Indentity.Models;

namespace TraineeTracker.Indentity
{
    public class TraineeTrackerIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public TraineeTrackerIdentityDbContext(DbContextOptions<TraineeTrackerIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
