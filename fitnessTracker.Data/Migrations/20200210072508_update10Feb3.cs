using Microsoft.EntityFrameworkCore.Migrations;

namespace fitnessTracker.Data.Migrations
{
    public partial class update10Feb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "DiscreteExercisePlans");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "DiscreteExercisePlans",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
