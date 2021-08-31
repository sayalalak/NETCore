using Microsoft.EntityFrameworkCore.Migrations;

namespace NETCore.Migrations
{
    public partial class add_newrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_persons_EducationId",
                table: "tb_tr_persons",
                column: "EducationId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_accounts_tb_m_persons_NIK",
                table: "tb_m_accounts",
                column: "NIK",
                principalTable: "tb_m_persons",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_persons_tb_m_accounts_NIK",
                table: "tb_tr_persons",
                column: "NIK",
                principalTable: "tb_m_accounts",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_persons_tb_tr_educations_EducationId",
                table: "tb_tr_persons",
                column: "EducationId",
                principalTable: "tb_tr_educations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_accounts_tb_m_persons_NIK",
                table: "tb_m_accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_persons_tb_m_accounts_NIK",
                table: "tb_tr_persons");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_persons_tb_tr_educations_EducationId",
                table: "tb_tr_persons");

            migrationBuilder.DropIndex(
                name: "IX_tb_tr_persons_EducationId",
                table: "tb_tr_persons");
        }
    }
}
