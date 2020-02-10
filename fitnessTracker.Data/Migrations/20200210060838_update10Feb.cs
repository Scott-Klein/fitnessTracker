using Microsoft.EntityFrameworkCore.Migrations;

namespace fitnessTracker.Data.Migrations
{
    public partial class update10Feb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscreteExercisePlan_UserProfiles_ProfileEmail",
                table: "DiscreteExercisePlan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiscreteExercisePlan",
                table: "DiscreteExercisePlan");

            migrationBuilder.RenameTable(
                name: "DiscreteExercisePlan",
                newName: "DiscreteExercisePlans");

            migrationBuilder.RenameIndex(
                name: "IX_DiscreteExercisePlan_ProfileEmail",
                table: "DiscreteExercisePlans",
                newName: "IX_DiscreteExercisePlans_ProfileEmail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiscreteExercisePlans",
                table: "DiscreteExercisePlans",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscreteExercisePlans_UserProfiles_ProfileEmail",
                table: "DiscreteExercisePlans",
                column: "ProfileEmail",
                principalTable: "UserProfiles",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscreteExercisePlans_UserProfiles_ProfileEmail",
                table: "DiscreteExercisePlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiscreteExercisePlans",
                table: "DiscreteExercisePlans");

            migrationBuilder.RenameTable(
                name: "DiscreteExercisePlans",
                newName: "DiscreteExercisePlan");

            migrationBuilder.RenameIndex(
                name: "IX_DiscreteExercisePlans_ProfileEmail",
                table: "DiscreteExercisePlan",
                newName: "IX_DiscreteExercisePlan_ProfileEmail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiscreteExercisePlan",
                table: "DiscreteExercisePlan",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscreteExercisePlan_UserProfiles_ProfileEmail",
                table: "DiscreteExercisePlan",
                column: "ProfileEmail",
                principalTable: "UserProfiles",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
