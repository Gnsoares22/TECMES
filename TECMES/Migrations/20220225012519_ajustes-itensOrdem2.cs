using Microsoft.EntityFrameworkCore.Migrations;

namespace TECMES.Migrations
{
    public partial class ajustesitensOrdem2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumeroSequencia",
                table: "OrdemProducaoSequencia",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroSequencia",
                table: "OrdemProducaoSequencia");
        }
    }
}
