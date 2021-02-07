using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortalAPI.Migrations
{
    public partial class changeTableNameCandidate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSkills_CandidateProfiles_CandidateId",
                table: "CandidateSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidateProfiles",
                table: "CandidateProfiles");

            migrationBuilder.RenameTable(
                name: "CandidateProfiles",
                newName: "Candidates");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidates",
                table: "Candidates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSkills_Candidates_CandidateId",
                table: "CandidateSkills",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSkills_Candidates_CandidateId",
                table: "CandidateSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidates",
                table: "Candidates");

            migrationBuilder.RenameTable(
                name: "Candidates",
                newName: "CandidateProfiles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidateProfiles",
                table: "CandidateProfiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSkills_CandidateProfiles_CandidateId",
                table: "CandidateSkills",
                column: "CandidateId",
                principalTable: "CandidateProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
