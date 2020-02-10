using Microsoft.EntityFrameworkCore.Migrations;

namespace fitnessTracker.Data.Migrations
{
    public partial class update10Feb5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiscreteExercisePlanid",
                table: "ExerciseSets",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSets_DiscreteExercisePlanid",
                table: "ExerciseSets",
                column: "DiscreteExercisePlanid");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseSets_DiscreteExercisePlans_DiscreteExercisePlanid",
                table: "ExerciseSets",
                column: "DiscreteExercisePlanid",
                principalTable: "DiscreteExercisePlans",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseSets_DiscreteExercisePlans_DiscreteExercisePlanid",
                table: "ExerciseSets");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseSets_DiscreteExercisePlanid",
                table: "ExerciseSets");

            migrationBuilder.DropColumn(
                name: "DiscreteExercisePlanid",
                table: "ExerciseSets");
        }
    }
}
