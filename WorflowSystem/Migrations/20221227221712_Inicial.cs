using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Worflow.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CEP = table.Column<string>(type: "varchar(8)", nullable: false),
                    Logadouro = table.Column<string>(type: "varchar(150)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(15)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(150)", nullable: false),
                    UF = table.Column<string>(type: "varchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Segmento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segmento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnderecoId = table.Column<int>(nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(14)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(150)", nullable: false),
                    Fantasia = table.Column<string>(type: "varchar(150)", nullable: false),
                    Agencia = table.Column<string>(type: "varchar(4)", nullable: false),
                    Conta = table.Column<string>(type: "varchar(5)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: true),
                    Telefone = table.Column<string>(type: "varchar(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    PerfilId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfil",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    SegmentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Segmento_SegmentoId",
                        column: x => x.SegmentoId,
                        principalTable: "Segmento",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lead",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    SegmentoId = table.Column<int>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    DataAgendada = table.Column<DateTime>(type: "datetime", nullable: false),
                    Observacao = table.Column<string>(type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lead", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lead_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lead_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lead_Segmento_SegmentoId",
                        column: x => x.SegmentoId,
                        principalTable: "Segmento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lead_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lead_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Perfil",
                columns: new[] { "Id", "Ativo", "Descricao" },
                values: new object[] { 1, true, "Consultor" });

            migrationBuilder.InsertData(
                table: "Segmento",
                columns: new[] { "Id", "Ativo", "Descricao" },
                values: new object[,]
                {
                    { 1, true, "Agro" },
                    { 2, true, "Cib" },
                    { 3, true, "Middle" },
                    { 4, true, "Large" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Ativo", "Descricao" },
                values: new object[,]
                {
                    { 1, true, "Ativo" },
                    { 2, true, "Em andamento" },
                    { 3, true, "Finalizado" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Ativo", "Nome", "PerfilId" },
                values: new object[] { 1, true, "Lionel Messi", 1 });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Ativo", "Nome", "PerfilId" },
                values: new object[] { 2, true, "Cristiano Ronaldo", 1 });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Ativo", "Nome", "PerfilId" },
                values: new object[] { 3, true, "Neymar Junior", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_EnderecoId",
                table: "Cliente",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTE_FANTASIA",
                table: "Cliente",
                column: "Fantasia");

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTE_RAZAO_SOCIAL",
                table: "Cliente",
                column: "RazaoSocial");

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECO_CIDADE",
                table: "Endereco",
                column: "Cidade");

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECO_LOGADOURO",
                table: "Endereco",
                column: "Logadouro");

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECO_UF",
                table: "Endereco",
                column: "UF");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_ClienteId",
                table: "Lead",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_ProdutoId",
                table: "Lead",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_SegmentoId",
                table: "Lead",
                column: "SegmentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_StatusId",
                table: "Lead",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Lead_UsuarioId",
                table: "Lead",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PERFIL_DESCRICAO",
                table: "Perfil",
                column: "Descricao");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTO_DESCRICAO",
                table: "Produto",
                column: "Descricao");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_SegmentoId",
                table: "Produto",
                column: "SegmentoId");

            migrationBuilder.CreateIndex(
                name: "IX_SEGMENTO_DESCRICAO",
                table: "Segmento",
                column: "Descricao");

            migrationBuilder.CreateIndex(
                name: "IX_STATUS_DESCRICAO",
                table: "Status",
                column: "Descricao");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_NOME",
                table: "Usuario",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PerfilId",
                table: "Usuario",
                column: "PerfilId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lead");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Segmento");

            migrationBuilder.DropTable(
                name: "Perfil");
        }
    }
}
