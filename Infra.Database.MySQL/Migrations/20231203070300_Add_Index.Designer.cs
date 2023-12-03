﻿// <auto-generated />
using System;
using Infra.Database.MySQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infra.Database.MySQL.Migrations
{
    [DbContext(typeof(RequirementDbContext))]
    [Migration("20231203070300_Add_Index")]
    partial class AddIndex
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Task.TaskEntity", b =>
                {
                    b.Property<string>("_id")
                        .HasMaxLength(36)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("ID");

                    b.Property<string>("CreatedById")
                        .HasMaxLength(36)
                        .HasColumnType("NVARCHAR");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("ModifiedById")
                        .HasMaxLength(36)
                        .HasColumnType("NVARCHAR");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("DATETIME");

                    b.Property<string>("OwnerId")
                        .HasMaxLength(36)
                        .HasColumnType("NVARCHAR");

                    b.Property<long?>("Period")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("StartedOn")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("UserStoryId")
                        .HasMaxLength(36)
                        .HasColumnType("NVARCHAR");

                    b.HasKey("_id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("OwnerId");

                    b.HasIndex("UserStoryId");

                    b.ToTable("Tasks", (string)null);
                });

            modelBuilder.Entity("Domain.UserRequirement.UserRequirementEntity", b =>
                {
                    b.Property<string>("_id")
                        .HasMaxLength(36)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("ID");

                    b.Property<string>("CreatedById")
                        .HasMaxLength(36)
                        .HasColumnType("NVARCHAR");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("ModifiedById")
                        .HasMaxLength(36)
                        .HasColumnType("NVARCHAR");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("DATETIME");

                    b.Property<string>("OwnerId")
                        .HasMaxLength(36)
                        .HasColumnType("NVARCHAR");

                    b.Property<long?>("Period")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("StartedOn")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR");

                    b.HasKey("_id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("OwnerId");

                    b.ToTable("UserRequirements", (string)null);
                });

            modelBuilder.Entity("Domain.UserStory.UserStoryEntity", b =>
                {
                    b.Property<string>("_id")
                        .HasMaxLength(36)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("ID");

                    b.Property<string>("CreatedById")
                        .HasMaxLength(36)
                        .HasColumnType("NVARCHAR");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("ModifiedById")
                        .HasMaxLength(36)
                        .HasColumnType("NVARCHAR");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("DATETIME");

                    b.Property<string>("OwnerId")
                        .HasMaxLength(36)
                        .HasColumnType("NVARCHAR");

                    b.Property<long?>("Period")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("StartedOn")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("UserRequirementId")
                        .HasMaxLength(36)
                        .HasColumnType("NVARCHAR");

                    b.HasKey("_id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("OwnerId");

                    b.HasIndex("UserRequirementId");

                    b.ToTable("UserStories", (string)null);
                });

            modelBuilder.Entity("Domain.Task.TaskEntity", b =>
                {
                    b.HasOne("Domain.UserStory.UserStoryEntity", null)
                        .WithMany("Tasks")
                        .HasForeignKey("UserStoryId");
                });

            modelBuilder.Entity("Domain.UserStory.UserStoryEntity", b =>
                {
                    b.HasOne("Domain.UserRequirement.UserRequirementEntity", null)
                        .WithMany("UserStories")
                        .HasForeignKey("UserRequirementId");
                });

            modelBuilder.Entity("Domain.UserRequirement.UserRequirementEntity", b =>
                {
                    b.Navigation("UserStories");
                });

            modelBuilder.Entity("Domain.UserStory.UserStoryEntity", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
