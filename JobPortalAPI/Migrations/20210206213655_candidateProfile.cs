using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortalAPI.Migrations
{
    public partial class candidateProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "candidateProfileid",
                table: "Skills",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CandidateProfiles",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    FName = table.Column<string>(type: "TEXT", nullable: true),
                    LName = table.Column<string>(type: "TEXT", nullable: true),
                    Experience = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateProfiles", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_candidateProfileid",
                table: "Skills",
                column: "candidateProfileid");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_CandidateProfiles_candidateProfileid",
                table: "Skills",
                column: "candidateProfileid",
                principalTable: "CandidateProfiles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_CandidateProfiles_candidateProfileid",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "CandidateProfiles");

            migrationBuilder.DropIndex(
                name: "IX_Skills_candidateProfileid",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "candidateProfileid",
                table: "Skills");
        }
    }
}
