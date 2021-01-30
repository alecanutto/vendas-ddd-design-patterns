using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vendas_AspNetCore_DDD.Infra.Data.Migrations
{
    public partial class Base : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CLIENTES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    CPF = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Telefone = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    CEP = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: true),
                    Endereco = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Numero = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Cidade = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    UF = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CLIENTES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PRODUTOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Unidade = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    Estoque = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUTOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_VENDEDORES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VENDEDORES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_VENDAS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVendedor = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    ValorProdutos = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ValorDesconto = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VENDAS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_VENDAS_TB_CLIENTES_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "TB_CLIENTES",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TB_VENDAS_TB_VENDEDORES_IdVendedor",
                        column: x => x.IdVendedor,
                        principalTable: "TB_VENDEDORES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TB_ITENS_VENDA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVenda = table.Column<int>(type: "int", nullable: false),
                    IdProduto = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Desconto = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ITENS_VENDA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_ITENS_VENDA_TB_PRODUTOS_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "TB_PRODUTOS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TB_ITENS_VENDA_TB_VENDAS_IdVenda",
                        column: x => x.IdVenda,
                        principalTable: "TB_VENDAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ITENS_VENDA_IdProduto",
                table: "TB_ITENS_VENDA",
                column: "IdProduto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_ITENS_VENDA_IdVenda",
                table: "TB_ITENS_VENDA",
                column: "IdVenda");

            migrationBuilder.CreateIndex(
                name: "IX_TB_VENDAS_IdCliente",
                table: "TB_VENDAS",
                column: "IdCliente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_VENDAS_IdVendedor",
                table: "TB_VENDAS",
                column: "IdVendedor",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ITENS_VENDA");

            migrationBuilder.DropTable(
                name: "TB_PRODUTOS");

            migrationBuilder.DropTable(
                name: "TB_VENDAS");

            migrationBuilder.DropTable(
                name: "TB_CLIENTES");

            migrationBuilder.DropTable(
                name: "TB_VENDEDORES");
        }
    }
}
