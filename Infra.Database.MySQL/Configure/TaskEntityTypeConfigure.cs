using Domain;
using Domain.Task;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Database.MySQL.Configure;

public class TaskEntityTypeConfigure : IEntityTypeConfiguration<TaskEntity>
{
    public void Configure(EntityTypeBuilder<TaskEntity> builder)
    {        
        builder.Property("_id").HasColumnName("ID").HasColumnType("NVARCHAR").HasMaxLength(36);
        builder.Property(t => t.Title).HasColumnType("NVARCHAR").HasMaxLength(255);
        builder.Property(t => t.Description).HasColumnType("NVARCHAR").HasMaxLength(255);
        builder.Property(t => t.OwnerId).HasColumnType("NVARCHAR").HasMaxLength(36);
        builder.Property(t => t.StartedOn).HasColumnType("DATETIME");
        builder.Property(t => t.Period).HasColumnType("bigint").HasConversion(t => t.HasValue ? t.Value.Ticks : default, t => t != default ? new TimeSpan(t) : default);
        builder.Property(t => t.Status).HasColumnType("NVARCHAR").HasMaxLength(255).HasConversion(t => t.Status, t => RecordStatus.Parse(t));
        builder.Property(t => t.ModifiedOn).HasColumnType("DATETIME");
        builder.Property(t => t.ModifiedById).HasColumnType("NVARCHAR").HasMaxLength(36);
        builder.Property(t => t.CreatedOn).HasColumnType("DATETIME");
        builder.Property(t => t.CreatedById).HasColumnType("NVARCHAR").HasMaxLength(36);
        builder.Property(t => t.UserStoryId).HasColumnType("NVARCHAR").HasMaxLength(36);

        builder.HasKey("_id");
        builder.HasIndex(t => t.OwnerId);
        builder.HasIndex(t => t.ModifiedById);
        builder.HasIndex(t => t.CreatedById);
        builder.HasIndex(t => t.UserStoryId);
        
        builder.Ignore(t => t.ID);

        builder.ToTable("Tasks");
    }
}
