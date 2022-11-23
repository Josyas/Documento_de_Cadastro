using Microsoft.EntityFrameworkCore.Migrations;

namespace UploadArquivoAula.Migrations
{
    public partial class infos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Arquivos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Codigo",
                table: "Arquivos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Processo",
                table: "Arquivos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Arquivos");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Arquivos");

            migrationBuilder.DropColumn(
                name: "Processo",
                table: "Arquivos");
        }
    }
}
