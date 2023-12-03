using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Database.MySQL.Migrations
{
    /// <inheritdoc />
    public partial class AddIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserStories_CreatedById",
                table: "UserStories",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserStories_ModifiedById",
                table: "UserStories",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserStories_OwnerId",
                table: "UserStories",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRequirements_CreatedById",
                table: "UserRequirements",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserRequirements_ModifiedById",
                table: "UserRequirements",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_UserRequirements_OwnerId",
                table: "UserRequirements",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CreatedById",
                table: "Tasks",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ModifiedById",
                table: "Tasks",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserStories_CreatedById",
                table: "UserStories");

            migrationBuilder.DropIndex(
                name: "IX_UserStories_ModifiedById",
                table: "UserStories");

            migrationBuilder.DropIndex(
                name: "IX_UserStories_OwnerId",
                table: "UserStories");

            migrationBuilder.DropIndex(
                name: "IX_UserRequirements_CreatedById",
                table: "UserRequirements");

            migrationBuilder.DropIndex(
                name: "IX_UserRequirements_ModifiedById",
                table: "UserRequirements");

            migrationBuilder.DropIndex(
                name: "IX_UserRequirements_OwnerId",
                table: "UserRequirements");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_CreatedById",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ModifiedById",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks");
        }
    }
}
