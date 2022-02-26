using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TECMES.Migrations
{
    public partial class ajustes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "quantidade",
                table: "Pedido",
                newName: "Quantidade");

            migrationBuilder.AlterColumn<int>(
                name: "quantidade",
                table: "OrdemProducao",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Prazo",
                table: "OrdemProducao",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "MaquinaID",
                table: "OrdemProducao",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "Pedido",
                newName: "quantidade");

            migrationBuilder.AlterColumn<int>(
                name: "quantidade",
                table: "OrdemProducao",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Prazo",
                table: "OrdemProducao",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaquinaID",
                table: "OrdemProducao",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
