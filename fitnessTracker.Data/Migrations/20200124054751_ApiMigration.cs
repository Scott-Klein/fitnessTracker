using Microsoft.EntityFrameworkCore.Migrations;

namespace fitnessTracker.Data.Migrations
{
    public partial class ApiMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "DiscreteExercisePlan",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ProfileEmail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscreteExercisePlan", x => x.id);
                    table.ForeignKey(
                        name: "FK_DiscreteExercisePlan_UserProfiles_ProfileEmail",
                        column: x => x.ProfileEmail,
                        principalTable: "UserProfiles",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscreteExercisePlan_ProfileEmail",
                table: "DiscreteExercisePlan",
                column: "ProfileEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscreteExercisePlan");

            migrationBuilder.DropTable(
                name: "UserProfiles");
        }
    }
}
