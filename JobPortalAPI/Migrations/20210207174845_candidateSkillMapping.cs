using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortalAPI.Migrations
{
    public partial class candidateSkillMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSkills_CandidateProfiles_profileid",
                table: "CandidateSkills");

            migrationBuilder.DropIndex(
                name: "IX_CandidateSkills_profileid",
                table: "CandidateSkills");

            migrationBuilder.DropColumn(
                name: "profileid",
                table: "CandidateSkills");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CandidateSkills",
                newName: "CandidateId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CandidateProfiles",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSkills_CandidateProfiles_CandidateId",
                table: "CandidateSkills",
                column: "CandidateId",
                principalTable: "CandidateProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateSkills_CandidateProfiles_CandidateId",
                table: "CandidateSkills");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "CandidateSkills",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CandidateProfiles",
                newName: "id");

            migrationBuilder.AddColumn<string>(
                name: "profileid",
                table: "CandidateSkills",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidateSkills_profileid",
                table: "CandidateSkills",
                column: "profileid");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateSkills_CandidateProfiles_profileid",
                table: "CandidateSkills",
                column: "profileid",
                principalTable: "CandidateProfiles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
