using Domain;
using Domain.Task;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Database.MySQL.Configure
{
    public class TaskEntityTypeConfigure : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            
            builder.Property("_id").HasColumnName("ID").HasColumnType("NVARCHAR").HasMaxLength(36);
            builder.Property(t => t.Title).HasColumnType("NVARCHAR");
            builder.Property(t => t.Description).HasColumnType("NVARCHAR");
            builder.Property(t => t.OwnerId).HasColumnType("NVARCHAR").HasMaxLength(36);
            builder.Property(t => t.StartedOn).HasColumnType("DATETIME2");
            builder.Property(t => t.Period).HasColumnType("TIME");
            builder.Property(t => t.Status).HasColumnType("NVARCHAR");
            builder.Property(t => t.ModifiedOn).HasColumnType("DATETIME2");
            builder.Property(t => t.ModifiedById).HasColumnType("NVARCHAR").HasMaxLength(36);
            builder.Property(t => t.CreatedOn).HasColumnType("DATETIME2");
            builder.Property(t => t.CreatedById).HasColumnType("NVARCHAR").HasMaxLength(36);
            builder.Property(t => t.UserStoryId).HasColumnType("NVARCHAR").HasMaxLength(36);

            builder.HasKey("_id");
            builder.ToTable("Tasks");
        }
    }
}
