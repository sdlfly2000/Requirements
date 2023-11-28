using Domain.UserStory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Database.MySQL.Configure;

public class UserStoryEntityTypeConfigure : IEntityTypeConfiguration<UserStoryEntity>
{
    public void Configure(EntityTypeBuilder<UserStoryEntity> builder)
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
        builder.Property(t => t.UserRequirementId).HasColumnType("NVARCHAR").HasMaxLength(36);

        builder.HasKey("_id");
        builder.ToTable("UserStories");
        builder.Ignore(t => t.Tasks);
        builder.HasMany(t => t.Tasks)
            .WithOne()
            .HasForeignKey(t => t.UserStoryId);
    }
}
