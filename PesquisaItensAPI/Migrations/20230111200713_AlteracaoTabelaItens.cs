using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PesquisaItensAPI.Migrations
{
    public partial class AlteracaoTabelaItens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "Itens",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Marca",
                table: "Itens");
        }
    }
}
