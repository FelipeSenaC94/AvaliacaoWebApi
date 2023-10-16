using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Avaliacao.Migrations
{
    public partial class IRRF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "IRRF",
                table: "FolhaPagamentos",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IRRF",
                table: "FolhaPagamentos");
        }
    }
}
