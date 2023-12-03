using Domain.Task;
using Domain.UserRequirement;
using Domain.UserStory;
using Infra.Database.MySQL.Configure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infra.Database.MySQL
{
    public class RequirementDbContext : DbContext
    {
        private readonly ILogger<RequirementDbContext> _logger;

        public RequirementDbContext(DbContextOptions<RequirementDbContext> options, ILogger<RequirementDbContext> logger)
            : base(options)
        {
            _logger = logger;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => _logger.LogInformation(message));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskEntityTypeConfigure());
            modelBuilder.ApplyConfiguration(new UserRequirementEntityTypeConfigure());
            modelBuilder.ApplyConfiguration(new UserStoryEntityTypeConfigure());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<UserStoryEntity> UserStories { get; set; }
        public DbSet<UserRequirementEntity> UserRequirements { get; set; }
    }
}
