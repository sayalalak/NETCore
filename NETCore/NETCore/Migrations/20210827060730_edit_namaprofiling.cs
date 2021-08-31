using Microsoft.EntityFrameworkCore.Migrations;

namespace NETCore.Migrations
{
    public partial class edit_namaprofiling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_persons_tb_m_accounts_NIK",
                table: "tb_tr_persons");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_persons_tb_tr_educations_EducationId",
                table: "tb_tr_persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_tr_persons",
                table: "tb_tr_persons");

            migrationBuilder.RenameTable(
                name: "tb_tr_persons",
                newName: "tb_tr_profilings");

            migrationBuilder.RenameIndex(
                name: "IX_tb_tr_persons_EducationId",
                table: "tb_tr_profilings",
                newName: "IX_tb_tr_profilings_EducationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_tr_profilings",
                table: "tb_tr_profilings",
                column: "NIK");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_profilings_tb_m_accounts_NIK",
                table: "tb_tr_profilings",
                column: "NIK",
                principalTable: "tb_m_accounts",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_tr_profilings_tb_tr_educations_EducationId",
                table: "tb_tr_profilings",
                column: "EducationId",
                principalTable: "tb_tr_educations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_profilings_tb_m_accounts_NIK",
                table: "tb_tr_profilings");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_tr_profilings_tb_tr_educations_EducationId",
                table: "tb_tr_profilings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_tr_profilings",
                table: "tb_tr_profilings");

            migrationBuilder.RenameTable(
                name: "tb_tr_profilings",
                newName: "tb_tr_persons");

            migrationBuilder.RenameIndex(
                name: "IX_tb_tr_profilings_EducationId",
                table: "tb_tr_persons",
                newName: "IX_tb_tr_persons_EducationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_tr_persons",
                table: "tb_tr_persons",
                column: "NIK");

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
    }
}
