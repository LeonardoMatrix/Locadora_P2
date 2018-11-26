using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Locadora.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    CPF = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.CPF);
                });

            migrationBuilder.CreateTable(
                name: "Sessao",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(nullable: true),
                    Localizacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessao", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Locacao",
                columns: table => new
                {
                    CodigoLocacao = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataLocacao = table.Column<DateTime>(nullable: false),
                    DataDevolucao = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    ClienteCPF = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacao", x => x.CodigoLocacao);
                    table.ForeignKey(
                        name: "FK_Locacao_Cliente_ClienteCPF",
                        column: x => x.ClienteCPF,
                        principalTable: "Cliente",
                        principalColumn: "CPF",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    CodigoVideo = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SessaoID = table.Column<int>(nullable: true),
                    Titulo = table.Column<string>(nullable: true),
                    Disponibilidade = table.Column<string>(nullable: true),
                    QuantidadeEstoque = table.Column<int>(nullable: false),
                    Genero = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.CodigoVideo);
                    table.ForeignKey(
                        name: "FK_Videos_Sessao_SessaoID",
                        column: x => x.SessaoID,
                        principalTable: "Sessao",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ator",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VideoCodigoVideo = table.Column<int>(nullable: true),
                    AtorPrincipal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ator", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ator_Videos_VideoCodigoVideo",
                        column: x => x.VideoCodigoVideo,
                        principalTable: "Videos",
                        principalColumn: "CodigoVideo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DVD",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VideoCodigoVideo = table.Column<int>(nullable: true),
                    LocacaoCodigoLocacao = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DVD", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DVD_Locacao_LocacaoCodigoLocacao",
                        column: x => x.LocacaoCodigoLocacao,
                        principalTable: "Locacao",
                        principalColumn: "CodigoLocacao",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DVD_Videos_VideoCodigoVideo",
                        column: x => x.VideoCodigoVideo,
                        principalTable: "Videos",
                        principalColumn: "CodigoVideo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ator_VideoCodigoVideo",
                table: "Ator",
                column: "VideoCodigoVideo");

            migrationBuilder.CreateIndex(
                name: "IX_DVD_LocacaoCodigoLocacao",
                table: "DVD",
                column: "LocacaoCodigoLocacao");

            migrationBuilder.CreateIndex(
                name: "IX_DVD_VideoCodigoVideo",
                table: "DVD",
                column: "VideoCodigoVideo");

            migrationBuilder.CreateIndex(
                name: "IX_Locacao_ClienteCPF",
                table: "Locacao",
                column: "ClienteCPF");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_SessaoID",
                table: "Videos",
                column: "SessaoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ator");

            migrationBuilder.DropTable(
                name: "DVD");

            migrationBuilder.DropTable(
                name: "Locacao");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Sessao");
        }
    }
}
