using Microsoft.EntityFrameworkCore.Migrations;

namespace TECMES.Migrations
{
    public partial class correcoes5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantidade",
                table: "Pedido",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantidade",
                table: "Pedido",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
