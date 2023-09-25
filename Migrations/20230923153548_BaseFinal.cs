using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CondominusApi.Migrations
{
    /// <inheritdoc />
    public partial class BaseFinal : Migration
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
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Perfil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Apartamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CondominioId = table.Column<int>(type: "int", nullable: true),
                    IdCondominio = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartamentos_Condominios_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "Condominios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Apartamentos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Perfil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApartamentoId = table.Column<int>(type: "int", nullable: true),
                    IdApartamento = table.Column<int>(type: "int", nullable: false),
                    CondominioId = table.Column<int>(type: "int", nullable: true),
                    IdCondominio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoas_Apartamentos_ApartamentoId",
                        column: x => x.ApartamentoId,
                        principalTable: "Apartamentos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pessoas_Condominios_CondominioId",
                        column: x => x.CondominioId,
                        principalTable: "Condominios",
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
                    PessoaId = table.Column<int>(type: "int", nullable: true),
                    IdPessoa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entregas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entregas_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataReserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PessoaId = table.Column<int>(type: "int", nullable: true),
                    IdPessoa = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Reservas_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Apartamentos",
                columns: new[] { "Id", "CondominioId", "IdCondominio", "Numero", "Status", "Telefone", "UsuarioId" },
                values: new object[,]
                {
                    { 1, null, 0, "A001", null, "11912345678", null },
                    { 2, null, 0, "B002", null, "11912345678", null },
                    { 3, null, 0, "C003", null, "11887654321", null },
                    { 4, null, 0, "E005", null, "11955555555", null }
                });

            migrationBuilder.InsertData(
                table: "AreasComuns",
                columns: new[] { "Id", "Capacidade", "Nome", "Status" },
                values: new object[,]
                {
                    { 1, 50, "Salão de Festas", null },
                    { 2, 30, "Churrasqueira", null },
                    { 3, 20, "Sala de Jogos", null },
                    { 4, 10, "Piscina", null }
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
                columns: new[] { "Id", "DataEntrega", "DataRetirada", "IdPessoa", "PessoaId", "Remetente" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 23, 12, 35, 48, 541, DateTimeKind.Local).AddTicks(976), new DateTime(2023, 9, 23, 12, 35, 48, 541, DateTimeKind.Local).AddTicks(987), 0, null, "Sorriso Maroto" },
                    { 2, new DateTime(2023, 9, 23, 12, 35, 48, 541, DateTimeKind.Local).AddTicks(988), new DateTime(2023, 9, 23, 12, 35, 48, 541, DateTimeKind.Local).AddTicks(989), 0, null, "Marilia Mendonça" },
                    { 3, new DateTime(2023, 9, 23, 12, 35, 48, 541, DateTimeKind.Local).AddTicks(990), new DateTime(2023, 9, 23, 12, 35, 48, 541, DateTimeKind.Local).AddTicks(990), 0, null, "Paola Oliveira" },
                    { 4, new DateTime(2023, 9, 23, 12, 35, 48, 541, DateTimeKind.Local).AddTicks(991), new DateTime(2023, 9, 23, 12, 35, 48, 541, DateTimeKind.Local).AddTicks(992), 0, null, "João Gomes" }
                });

            migrationBuilder.InsertData(
                table: "Pessoas",
                columns: new[] { "Id", "ApartamentoId", "CondominioId", "Cpf", "IdApartamento", "IdCondominio", "Nome", "Perfil", "Status", "Telefone" },
                values: new object[,]
                {
                    { 1, null, null, "56751898901", 0, 0, "João Gomes", null, null, "11924316523" },
                    { 2, null, null, "63158658205", 0, 0, "Paola Oliveira", null, null, "11975231678" },
                    { 3, null, null, "27458823908", 0, 0, "Marilia Mendonça", null, null, "11937512056" },
                    { 4, null, null, "32152898910", 0, 0, "Sorriso Maroto", null, null, "11987618735" }
                });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "Id", "AreaComumId", "DataReserva", "IdAreaComum", "IdPessoa", "PessoaId", "Status" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 9, 23, 12, 35, 48, 541, DateTimeKind.Local).AddTicks(1025), 0, 0, null, null },
                    { 2, null, new DateTime(2023, 9, 23, 12, 35, 48, 541, DateTimeKind.Local).AddTicks(1026), 0, 0, null, null },
                    { 3, null, new DateTime(2023, 9, 23, 12, 35, 48, 541, DateTimeKind.Local).AddTicks(1027), 0, 0, null, null },
                    { 4, null, new DateTime(2023, 9, 23, 12, 35, 48, 541, DateTimeKind.Local).AddTicks(1028), 0, 0, null, null }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "DataAcesso", "Email", "Nome", "PasswordHash", "PasswordSalt", "Perfil" },
                values: new object[,]
                {
                    { 1, null, "seuEmail@gmail.com", "UsuarioAdmin", new byte[] { 157, 142, 237, 117, 236, 151, 56, 133, 167, 218, 252, 90, 28, 217, 229, 122, 210, 204, 148, 144, 117, 248, 206, 208, 10, 12, 172, 52, 115, 235, 91, 135, 13, 118, 30, 239, 116, 159, 242, 57, 253, 140, 16, 141, 72, 135, 76, 47, 87, 251, 63, 26, 125, 193, 168, 29, 154, 216, 206, 72, 46, 205, 80, 76 }, new byte[] { 89, 151, 151, 250, 180, 108, 212, 72, 124, 202, 251, 253, 165, 247, 4, 173, 47, 83, 106, 193, 214, 183, 116, 252, 213, 173, 37, 154, 123, 24, 191, 160, 134, 12, 74, 14, 153, 225, 109, 119, 53, 80, 22, 129, 136, 3, 169, 86, 74, 134, 222, 249, 71, 231, 94, 41, 252, 243, 46, 163, 174, 226, 43, 195, 89, 148, 165, 160, 89, 21, 29, 255, 173, 183, 207, 104, 161, 2, 164, 236, 12, 153, 153, 204, 122, 16, 42, 86, 232, 2, 149, 69, 59, 20, 132, 41, 183, 65, 219, 190, 59, 205, 103, 91, 53, 32, 201, 203, 101, 254, 28, 165, 228, 186, 218, 205, 244, 96, 229, 249, 218, 236, 160, 41, 189, 203, 236, 12 }, "Admin" },
                    { 3, null, "email@gmail.com", "UsuarioSindico", new byte[] { 157, 142, 237, 117, 236, 151, 56, 133, 167, 218, 252, 90, 28, 217, 229, 122, 210, 204, 148, 144, 117, 248, 206, 208, 10, 12, 172, 52, 115, 235, 91, 135, 13, 118, 30, 239, 116, 159, 242, 57, 253, 140, 16, 141, 72, 135, 76, 47, 87, 251, 63, 26, 125, 193, 168, 29, 154, 216, 206, 72, 46, 205, 80, 76 }, new byte[] { 89, 151, 151, 250, 180, 108, 212, 72, 124, 202, 251, 253, 165, 247, 4, 173, 47, 83, 106, 193, 214, 183, 116, 252, 213, 173, 37, 154, 123, 24, 191, 160, 134, 12, 74, 14, 153, 225, 109, 119, 53, 80, 22, 129, 136, 3, 169, 86, 74, 134, 222, 249, 71, 231, 94, 41, 252, 243, 46, 163, 174, 226, 43, 195, 89, 148, 165, 160, 89, 21, 29, 255, 173, 183, 207, 104, 161, 2, 164, 236, 12, 153, 153, 204, 122, 16, 42, 86, 232, 2, 149, 69, 59, 20, 132, 41, 183, 65, 219, 190, 59, 205, 103, 91, 53, 32, 201, 203, 101, 254, 28, 165, 228, 186, 218, 205, 244, 96, 229, 249, 218, 236, 160, 41, 189, 203, 236, 12 }, "Sindico" },
                    { 4, null, "email@gmail.com", "UsuarioMorador", new byte[] { 157, 142, 237, 117, 236, 151, 56, 133, 167, 218, 252, 90, 28, 217, 229, 122, 210, 204, 148, 144, 117, 248, 206, 208, 10, 12, 172, 52, 115, 235, 91, 135, 13, 118, 30, 239, 116, 159, 242, 57, 253, 140, 16, 141, 72, 135, 76, 47, 87, 251, 63, 26, 125, 193, 168, 29, 154, 216, 206, 72, 46, 205, 80, 76 }, new byte[] { 89, 151, 151, 250, 180, 108, 212, 72, 124, 202, 251, 253, 165, 247, 4, 173, 47, 83, 106, 193, 214, 183, 116, 252, 213, 173, 37, 154, 123, 24, 191, 160, 134, 12, 74, 14, 153, 225, 109, 119, 53, 80, 22, 129, 136, 3, 169, 86, 74, 134, 222, 249, 71, 231, 94, 41, 252, 243, 46, 163, 174, 226, 43, 195, 89, 148, 165, 160, 89, 21, 29, 255, 173, 183, 207, 104, 161, 2, 164, 236, 12, 153, 153, 204, 122, 16, 42, 86, 232, 2, 149, 69, 59, 20, 132, 41, 183, 65, 219, 190, 59, 205, 103, 91, 53, 32, 201, 203, 101, 254, 28, 165, 228, 186, 218, 205, 244, 96, 229, 249, 218, 236, 160, 41, 189, 203, 236, 12 }, "Morador" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartamentos_CondominioId",
                table: "Apartamentos",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartamentos_UsuarioId",
                table: "Apartamentos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_PessoaId",
                table: "Entregas",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_ApartamentoId",
                table: "Pessoas",
                column: "ApartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_CondominioId",
                table: "Pessoas",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_AreaComumId",
                table: "Reservas",
                column: "AreaComumId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_PessoaId",
                table: "Reservas",
                column: "PessoaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entregas");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "AreasComuns");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Apartamentos");

            migrationBuilder.DropTable(
                name: "Condominios");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
