using Microsoft.EntityFrameworkCore.Migrations;

namespace Corrente.Migrations
{
    public partial class TipoInstituicaoForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instituicao_TipoInstituicao_TipoInstituicaoId",
                table: "Instituicao");

            migrationBuilder.AlterColumn<int>(
                name: "TipoInstituicaoId",
                table: "Instituicao",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Instituicao_TipoInstituicao_TipoInstituicaoId",
                table: "Instituicao",
                column: "TipoInstituicaoId",
                principalTable: "TipoInstituicao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instituicao_TipoInstituicao_TipoInstituicaoId",
                table: "Instituicao");

            migrationBuilder.AlterColumn<int>(
                name: "TipoInstituicaoId",
                table: "Instituicao",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Instituicao_TipoInstituicao_TipoInstituicaoId",
                table: "Instituicao",
                column: "TipoInstituicaoId",
                principalTable: "TipoInstituicao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
