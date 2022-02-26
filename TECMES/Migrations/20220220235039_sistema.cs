using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TECMES.Migrations
{
    public partial class sistema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maquina",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maquina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdemProducaoStatus",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemProducaoStatus", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    preco = table.Column<decimal>(nullable: false),
                    quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

  
            migrationBuilder.CreateTable(
                name: "OrdemProducao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantidade = table.Column<int>(nullable: false),
                    Prazo = table.Column<DateTime>(nullable: false),
                    ProdutoID = table.Column<int>(nullable: false),
                    StatusID = table.Column<int>(nullable: false),
                    MaquinaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemProducao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdemProducao_Maquina_MaquinaID",
                        column: x => x.MaquinaID,
                        principalTable: "Maquina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdemProducao_Produto_ProdutoID",
                        column: x => x.ProdutoID,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdemProducao_OrdemProducaoStatus_StatusID",
                        column: x => x.StatusID,
                        principalTable: "OrdemProducaoStatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoID = table.Column<int>(nullable: false),
                    ClienteID = table.Column<int>(nullable: false),
                    quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_Produto_ProdutoID",
                        column: x => x.ProdutoID,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdemProducaoSequencia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdemProducaoID = table.Column<int>(nullable: false),
                    ProdutoID = table.Column<int>(nullable: false),
                    StatusID = table.Column<int>(nullable: false),
                    OrdemProducaoStatusid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemProducaoSequencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdemProducaoSequencia_OrdemProducao_OrdemProducaoID",
                        column: x => x.OrdemProducaoID,
                        principalTable: "OrdemProducao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdemProducaoSequencia_OrdemProducaoStatus_OrdemProducaoStatusid",
                        column: x => x.OrdemProducaoStatusid,
                        principalTable: "OrdemProducaoStatus",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdemProducaoSequencia_Produto_ProdutoID",
                        column: x => x.ProdutoID,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdemProducao_MaquinaID",
                table: "OrdemProducao",
                column: "MaquinaID");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemProducao_ProdutoID",
                table: "OrdemProducao",
                column: "ProdutoID");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemProducao_StatusID",
                table: "OrdemProducao",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemProducaoSequencia_OrdemProducaoID",
                table: "OrdemProducaoSequencia",
                column: "OrdemProducaoID");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemProducaoSequencia_OrdemProducaoStatusid",
                table: "OrdemProducaoSequencia",
                column: "OrdemProducaoStatusid");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemProducaoSequencia_ProdutoID",
                table: "OrdemProducaoSequencia",
                column: "ProdutoID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteID",
                table: "Pedido",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ProdutoID",
                table: "Pedido",
                column: "ProdutoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdemProducaoSequencia");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "OrdemProducao");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Maquina");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "OrdemProducaoStatus");
        }
    }
}
