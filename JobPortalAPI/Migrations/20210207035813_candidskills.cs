using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortalAPI.Migrations
{
    public partial class candidskills : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSkills_CandidateProfiles_CandidateProfileid",
                table: "CandidateSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_CandidateProfiles_candidateProfileid",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_candidateProfileid",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "candidateProfileid",
                table: "Skills");

            migrationBuilder.RenameColumn(
                name: "CandidateProfileid",
                table: "CandidateSkills",
                newName: "profileid");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateSkills_CandidateProfileid",
                table: "CandidateSkills",
                newName: "IX_CandidateSkills_profileid");

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "CandidateSkills",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSkills_CandidateProfiles_profileid",
                table: "CandidateSkills",
                column: "profileid",
                principalTable: "CandidateProfiles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSkills_CandidateProfiles_profileid",
                table: "CandidateSkills");

            migrationBuilder.RenameColumn(
                name: "profileid",
                table: "CandidateSkills",
                newName: "CandidateProfileid");

            migrationBuilder.RenameIndex(
                name: "IX_CandidateSkills_profileid",
                table: "CandidateSkills",
                newName: "IX_CandidateSkills_CandidateProfileid");

            migrationBuilder.AddColumn<string>(
                name: "candidateProfileid",
                table: "Skills",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "CandidateSkills",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_candidateProfileid",
                table: "Skills",
                column: "candidateProfileid");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSkills_CandidateProfiles_CandidateProfileid",
                table: "CandidateSkills",
                column: "CandidateProfileid",
                principalTable: "CandidateProfiles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_CandidateProfiles_candidateProfileid",
                table: "Skills",
                column: "candidateProfileid",
                principalTable: "CandidateProfiles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
