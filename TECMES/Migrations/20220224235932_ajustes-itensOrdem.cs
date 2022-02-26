using Microsoft.EntityFrameworkCore.Migrations;

namespace TECMES.Migrations
{
    public partial class ajustesitensOrdem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OrdemProducaoStatusId",
                table: "OrdemProducaoSequencia",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "OrdemProducaoSequencia",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "OrdemProducaoSequencia");

            migrationBuilder.AlterColumn<int>(
                name: "OrdemProducaoStatusId",
                table: "OrdemProducaoSequencia",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
