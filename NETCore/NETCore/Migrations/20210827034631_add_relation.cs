using Microsoft.EntityFrameworkCore.Migrations;

namespace NETCore.Migrations
{
    public partial class add_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_educations_UniversityId",
                table: "tb_tr_educations",
                column: "UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_educations_tb_m_universities_UniversityId",
                table: "tb_tr_educations",
                column: "UniversityId",
                principalTable: "tb_m_universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_educations_tb_m_universities_UniversityId",
                table: "tb_tr_educations");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_educations_UniversityId",
                table: "tb_tr_educations");
        }
    }
}
