using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Database.MySQL.Migrations
{
    /// <inheritdoc />
    public partial class UserRequirementEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRequirements",
                columns: table => new
                {
                    ID = table.Column<string>(type: "NVARCHAR(36)", maxLength: 36, nullable: false),
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
                    table.PrimaryKey("PK_UserRequirements", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserStories_UserRequirementId",
                table: "UserStories",
                column: "UserRequirementId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserStories_UserRequirements_UserRequirementId",
                table: "UserStories",
                column: "UserRequirementId",
                principalTable: "UserRequirements",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserStories_UserRequirements_UserRequirementId",
                table: "UserStories");

            migrationBuilder.DropTable(
                name: "UserRequirements");

            migrationBuilder.DropIndex(
                name: "IX_UserStories_UserRequirementId",
                table: "UserStories");
        }
    }
}
