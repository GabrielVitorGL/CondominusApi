using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CondominusApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreasComuns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacidade = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasComuns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Condominios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condominios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Apartamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CondominioId = table.Column<int>(type: "int", nullable: true),
                    IdCondominio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartamentos_Condominios_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "Condominios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sindicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CondominioId = table.Column<int>(type: "int", nullable: true),
                    IdCondominio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sindicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sindicos_Condominios_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "Condominios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Moradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApartamentoId = table.Column<int>(type: "int", nullable: true),
                    IdApartamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moradores_Apartamentos_ApartamentoId",
                        column: x => x.ApartamentoId,
                        principalTable: "Apartamentos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Entregas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Remetente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataRetirada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoradorId = table.Column<int>(type: "int", nullable: true),
                    IdMorador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entregas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entregas_Moradores_MoradorId",
                        column: x => x.MoradorId,
                        principalTable: "Moradores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataReserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoradorId = table.Column<int>(type: "int", nullable: true),
                    IdMorador = table.Column<int>(type: "int", nullable: false),
                    AreaComumId = table.Column<int>(type: "int", nullable: true),
                    IdAreaComum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_AreasComuns_AreaComumId",
                        column: x => x.AreaComumId,
                        principalTable: "AreasComuns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservas_Moradores_MoradorId",
                        column: x => x.MoradorId,
                        principalTable: "Moradores",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Apartamentos",
                columns: new[] { "Id", "CondominioId", "IdCondominio", "Numero", "Telefone" },
                values: new object[,]
                {
                    { 1, null, 0, "A001", "11912345678" },
                    { 2, null, 0, "B002", "11912345678" },
                    { 3, null, 0, "C003", "11887654321" },
                    { 4, null, 0, "E005", "11955555555" }
                });

            migrationBuilder.InsertData(
                table: "AreasComuns",
                columns: new[] { "Id", "Capacidade", "Nome" },
                values: new object[,]
                {
                    { 1, 50, "Salão de Festas" },
                    { 2, 30, "Churrasqueira" },
                    { 3, 20, "Sala de Jogos" },
                    { 4, 10, "Piscina" }
                });

            migrationBuilder.InsertData(
                table: "Condominios",
                columns: new[] { "Id", "Endereco", "Nome" },
                values: new object[,]
                {
                    { 1, "Rua Guaranésia, 1070", "Vila Nova Maria" },
                    { 2, "Rua Paulo Andrighetti, 1573", "Condomínio Aquarella Pari Colore" },
                    { 3, "Rua Paulo Andrighetti, 449", "Condomínio Edifício Antônio Walter Santiago" },
                    { 4, "Rua Eugênio de Freitas, 525", "Condomínio Edifício Veneza" }
                });

            migrationBuilder.InsertData(
                table: "Entregas",
                columns: new[] { "Id", "DataEntrega", "DataRetirada", "IdMorador", "MoradorId", "Remetente" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 28, 11, 13, 57, 917, DateTimeKind.Local).AddTicks(3535), new DateTime(2023, 8, 28, 11, 13, 57, 917, DateTimeKind.Local).AddTicks(3546), 0, null, "Sorriso Maroto" },
                    { 2, new DateTime(2023, 8, 28, 11, 13, 57, 917, DateTimeKind.Local).AddTicks(3547), new DateTime(2023, 8, 28, 11, 13, 57, 917, DateTimeKind.Local).AddTicks(3547), 0, null, "Marilia Mendonça" },
                    { 3, new DateTime(2023, 8, 28, 11, 13, 57, 917, DateTimeKind.Local).AddTicks(3548), new DateTime(2023, 8, 28, 11, 13, 57, 917, DateTimeKind.Local).AddTicks(3549), 0, null, "Paola Oliveira" },
                    { 4, new DateTime(2023, 8, 28, 11, 13, 57, 917, DateTimeKind.Local).AddTicks(3550), new DateTime(2023, 8, 28, 11, 13, 57, 917, DateTimeKind.Local).AddTicks(3550), 0, null, "João Gomes" }
                });

            migrationBuilder.InsertData(
                table: "Moradores",
                columns: new[] { "Id", "ApartamentoId", "Cpf", "IdApartamento", "Nome", "Telefone" },
                values: new object[,]
                {
                    { 1, null, "56751898901", 0, "João Gomes", "11924316523" },
                    { 2, null, "63158658205", 0, "Paola Oliveira", "11975231678" },
                    { 3, null, "27458823908", 0, "Marilia Mendonça", "11937512056" },
                    { 4, null, "32152898910", 0, "Sorriso Maroto", "11987618735" }
                });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "Id", "AreaComumId", "DataReserva", "IdAreaComum", "IdMorador", "MoradorId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 8, 28, 11, 13, 57, 917, DateTimeKind.Local).AddTicks(3600), 0, 0, null },
                    { 2, null, new DateTime(2023, 8, 28, 11, 13, 57, 917, DateTimeKind.Local).AddTicks(3601), 0, 0, null },
                    { 3, null, new DateTime(2023, 8, 28, 11, 13, 57, 917, DateTimeKind.Local).AddTicks(3602), 0, 0, null },
                    { 4, null, new DateTime(2023, 8, 28, 11, 13, 57, 917, DateTimeKind.Local).AddTicks(3602), 0, 0, null }
                });

            migrationBuilder.InsertData(
                table: "Sindicos",
                columns: new[] { "Id", "CondominioId", "Cpf", "IdCondominio", "Nome", "Telefone" },
                values: new object[] { 1, null, "12345678900", 0, "Eliane Marion", "11925874613" });

            migrationBuilder.CreateIndex(
                name: "IX_Apartamentos_CondominioId",
                table: "Apartamentos",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_MoradorId",
                table: "Entregas",
                column: "MoradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Moradores_ApartamentoId",
                table: "Moradores",
                column: "ApartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_AreaComumId",
                table: "Reservas",
                column: "AreaComumId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_MoradorId",
                table: "Reservas",
                column: "MoradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sindicos_CondominioId",
                table: "Sindicos",
                column: "CondominioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entregas");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Sindicos");

            migrationBuilder.DropTable(
                name: "AreasComuns");

            migrationBuilder.DropTable(
                name: "Moradores");

            migrationBuilder.DropTable(
                name: "Apartamentos");

            migrationBuilder.DropTable(
                name: "Condominios");
        }
    }
}
