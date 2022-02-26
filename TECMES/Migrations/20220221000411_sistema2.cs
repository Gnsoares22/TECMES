using Microsoft.EntityFrameworkCore.Migrations;

namespace TECMES.Migrations
{
    public partial class sistema2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdemProducaoSequencia_OrdemProducaoStatus_OrdemProducaoStatusid",
                table: "OrdemProducaoSequencia");

            migrationBuilder.DropColumn(
                name: "StatusID",
                table: "OrdemProducaoSequencia");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "OrdemProducaoStatus",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "OrdemProducaoStatusid",
                table: "OrdemProducaoSequencia",
                newName: "OrdemProducaoStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_OrdemProducaoSequencia_OrdemProducaoStatusid",
                table: "OrdemProducaoSequencia",
                newName: "IX_OrdemProducaoSequencia_OrdemProducaoStatusId");

            migrationBuilder.AlterColumn<int>(
                name: "OrdemProducaoStatusId",
                table: "OrdemProducaoSequencia",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdemProducaoSequencia_OrdemProducaoStatus_OrdemProducaoStatusId",
                table: "OrdemProducaoSequencia",
                column: "OrdemProducaoStatusId",
                principalTable: "OrdemProducaoStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdemProducaoSequencia_OrdemProducaoStatus_OrdemProducaoStatusId",
                table: "OrdemProducaoSequencia");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OrdemProducaoStatus",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "OrdemProducaoStatusId",
                table: "OrdemProducaoSequencia",
                newName: "OrdemProducaoStatusid");

            migrationBuilder.RenameIndex(
                name: "IX_OrdemProducaoSequencia_OrdemProducaoStatusId",
                table: "OrdemProducaoSequencia",
                newName: "IX_OrdemProducaoSequencia_OrdemProducaoStatusid");

            migrationBuilder.AlterColumn<int>(
                name: "OrdemProducaoStatusid",
                table: "OrdemProducaoSequencia",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "StatusID",
                table: "OrdemProducaoSequencia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdemProducaoSequencia_OrdemProducaoStatus_OrdemProducaoStatusid",
                table: "OrdemProducaoSequencia",
                column: "OrdemProducaoStatusid",
                principalTable: "OrdemProducaoStatus",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
