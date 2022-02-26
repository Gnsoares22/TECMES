using Microsoft.EntityFrameworkCore.Migrations;

namespace TECMES.Migrations
{
    public partial class correcoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PedidoID",
                table: "OrdemProducao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrdemProducao_PedidoID",
                table: "OrdemProducao",
                column: "PedidoID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdemProducao_Pedido_PedidoID",
                table: "OrdemProducao",
                column: "PedidoID",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdemProducao_Pedido_PedidoID",
                table: "OrdemProducao");

            migrationBuilder.DropIndex(
                name: "IX_OrdemProducao_PedidoID",
                table: "OrdemProducao");

            migrationBuilder.DropColumn(
                name: "PedidoID",
                table: "OrdemProducao");
        }
    }
}
