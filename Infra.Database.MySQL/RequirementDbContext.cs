using Domain.Task;
using Domain.UserStory;
using Infra.Database.MySQL.Configure;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.MySQL
{
    public class RequirementDbContext : DbContext
    {
        public RequirementDbContext(DbContextOptions<RequirementDbContext> options)
            : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskEntityTypeConfigure());
            modelBuilder.ApplyConfiguration(new UserStoryEntityTypeConfigure());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<UserStoryEntity> UserStories { get; set; }
    }
}
