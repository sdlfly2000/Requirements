using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Database.MySQL.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableTaskUserStories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserStories",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR(36)", maxLength: 36, nullable: false),
                    UserRequirementId = table.Column<string>(type: "NVARCHAR(36)", maxLength: 36, nullable: true),
                    Title = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: true),
                    OwnerId = table.Column<string>(type: "NVARCHAR(36)", maxLength: 36, nullable: true),
                    StartedOn = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Period = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    ModifiedById = table.Column<string>(type: "NVARCHAR(36)", maxLength: 36, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    CreatedById = table.Column<string>(type: "NVARCHAR(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStories", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR(36)", maxLength: 36, nullable: false),
                    UserStoryId = table.Column<string>(type: "NVARCHAR(36)", maxLength: 36, nullable: true),
                    Title = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: true),
                    OwnerId = table.Column<string>(type: "NVARCHAR(36)", maxLength: 36, nullable: true),
                    StartedOn = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Period = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    ModifiedById = table.Column<string>(type: "NVARCHAR(36)", maxLength: 36, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    CreatedById = table.Column<string>(type: "NVARCHAR(36)", maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tasks_UserStories_UserStoryId",
                        column: x => x.UserStoryId,
                        principalTable: "UserStories",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserStoryId",
                table: "Tasks",
                column: "UserStoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "UserStories");
        }
    }
}
