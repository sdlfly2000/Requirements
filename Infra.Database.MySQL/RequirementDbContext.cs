using Domain.Task;
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
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TaskEntity> Tasks { get; set; }
    }
}
