using Microsoft.EntityFrameworkCore.Migrations;

namespace NETCore.Migrations
{
    public partial class update_tablename2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Universities",
                table: "Universities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profilings",
                table: "Profilings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Educations",
                table: "Educations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Universities",
                newName: "tb_m_universities");

            migrationBuilder.RenameTable(
                name: "Profilings",
                newName: "tb_tr_persons");

            migrationBuilder.RenameTable(
                name: "Educations",
                newName: "tb_tr_educations");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "tb_m_accounts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_universities",
                table: "tb_m_universities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_tr_persons",
                table: "tb_tr_persons",
                column: "NIK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_tr_educations",
                table: "tb_tr_educations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_m_accounts",
                table: "tb_m_accounts",
                column: "NIK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_tr_persons",
                table: "tb_tr_persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_tr_educations",
                table: "tb_tr_educations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_universities",
                table: "tb_m_universities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_m_accounts",
                table: "tb_m_accounts");

            migrationBuilder.RenameTable(
                name: "tb_tr_persons",
                newName: "Profilings");

            migrationBuilder.RenameTable(
                name: "tb_tr_educations",
                newName: "Educations");

            migrationBuilder.RenameTable(
                name: "tb_m_universities",
                newName: "Universities");

            migrationBuilder.RenameTable(
                name: "tb_m_accounts",
                newName: "Accounts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profilings",
                table: "Profilings",
                column: "NIK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Educations",
                table: "Educations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Universities",
                table: "Universities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "NIK");
        }
    }
}
