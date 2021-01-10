using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortalAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    role = table.Column<string>(type: "TEXT", nullable: true),
                    noOfOpenings = table.Column<int>(type: "INTEGER", nullable: false),
                    skills = table.Column<string>(type: "TEXT", nullable: true),
                    jobLocation = table.Column<string>(type: "TEXT", nullable: true),
                    yearsOfExperience = table.Column<int>(type: "INTEGER", nullable: false),
                    noOfApplicants = table.Column<int>(type: "INTEGER", nullable: false),
                    isActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    company = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
