using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CondominusApi.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioComPessoa : Migration
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
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Perfil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Portarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portarias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Avisos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Assunto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mensagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataEnvio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PessoaId = table.Column<int>(type: "int", nullable: true),
                    IdPessoa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avisos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avisos_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Dependentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PessoaId = table.Column<int>(type: "int", nullable: true),
                    IdPessoa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dependentes_Pessoas_PessoaId",
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
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Condominios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortariaId = table.Column<int>(type: "int", nullable: true),
                    IdPortaria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condominios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Condominios_Portarias_PortariaId",
                        column: x => x.PortariaId,
                        principalTable: "Portarias",
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
                    IdPessoa = table.Column<int>(type: "int", nullable: false),
                    PortariaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entregas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entregas_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Entregas_Portarias_PortariaId",
                        column: x => x.PortariaId,
                        principalTable: "Portarias",
                        principalColumn: "Id");
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
                name: "ApartPessoas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartamentoId = table.Column<int>(type: "int", nullable: true),
                    IdApartamento = table.Column<int>(type: "int", nullable: false),
                    PessoaId = table.Column<int>(type: "int", nullable: true),
                    IdPessoa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartPessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApartPessoas_Apartamentos_ApartamentoId",
                        column: x => x.ApartamentoId,
                        principalTable: "Apartamentos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApartPessoas_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Perfil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApartamentoId = table.Column<int>(type: "int", nullable: true),
                    IdApartamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Apartamentos_ApartamentoId",
                        column: x => x.ApartamentoId,
                        principalTable: "Apartamentos",
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
                columns: new[] { "Id", "Endereco", "IdPortaria", "Nome", "PortariaId" },
                values: new object[,]
                {
                    { 1, "Rua Guaranésia, 1070", 0, "Vila Nova Maria", null },
                    { 2, "Rua Paulo Andrighetti, 1573", 0, "Condomínio Aquarella Pari Colore", null },
                    { 3, "Rua Paulo Andrighetti, 449", 0, "Condomínio Edifício Antônio Walter Santiago", null },
                    { 4, "Rua Eugênio de Freitas, 525", 0, "Condomínio Edifício Veneza", null }
                });

            migrationBuilder.InsertData(
                table: "Pessoas",
                columns: new[] { "Id", "Cpf", "Nome", "Perfil", "Telefone" },
                values: new object[,]
                {
                    { 1, "56751898901", "João Gomes", null, "11924316523" },
                    { 2, "63158658205", "Paola Oliveira", null, "11975231678" },
                    { 3, "27458823908", "Marilia Mendonça", null, "11937512056" },
                    { 4, "32152898910", "Sorriso Maroto", null, "11987618735" }
                });

            migrationBuilder.InsertData(
                table: "Reservas",
                columns: new[] { "Id", "AreaComumId", "Data", "IdAreaComum", "IdPessoa", "PessoaId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, null },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, null },
                    { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, null },
                    { 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, null }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "ApartamentoId", "Cpf", "DataAcesso", "Email", "IdApartamento", "Nome", "PasswordHash", "PasswordSalt", "Perfil", "Telefone" },
                values: new object[,]
                {
                    { 1, null, null, null, "seuEmail@gmail.com", 1, "UsuarioAdmin", new byte[] { 37, 216, 254, 13, 90, 64, 85, 175, 104, 222, 220, 64, 86, 228, 62, 68, 199, 21, 82, 58, 121, 120, 162, 23, 80, 42, 202, 213, 150, 119, 167, 75, 39, 236, 207, 28, 173, 249, 27, 173, 14, 193, 225, 55, 131, 137, 22, 247, 184, 65, 44, 104, 145, 133, 183, 138, 180, 178, 127, 26, 20, 192, 14, 210 }, new byte[] { 87, 203, 55, 225, 10, 188, 236, 183, 66, 69, 42, 241, 56, 109, 80, 114, 41, 54, 124, 223, 104, 184, 141, 131, 40, 72, 242, 118, 137, 141, 136, 171, 38, 233, 103, 45, 86, 33, 145, 113, 239, 162, 86, 41, 245, 162, 142, 101, 247, 165, 250, 223, 117, 4, 77, 73, 59, 254, 84, 120, 167, 180, 1, 73, 143, 234, 160, 75, 202, 64, 25, 149, 65, 77, 119, 7, 8, 133, 124, 157, 171, 2, 149, 163, 48, 226, 75, 158, 120, 217, 17, 178, 143, 204, 182, 56, 29, 23, 255, 2, 221, 62, 129, 185, 213, 123, 63, 25, 232, 6, 206, 211, 172, 211, 185, 224, 200, 58, 232, 254, 142, 86, 184, 170, 83, 155, 198, 25 }, "Admin", null },
                    { 3, null, null, null, "email@gmail.com", 2, "UsuarioSindico", new byte[] { 37, 216, 254, 13, 90, 64, 85, 175, 104, 222, 220, 64, 86, 228, 62, 68, 199, 21, 82, 58, 121, 120, 162, 23, 80, 42, 202, 213, 150, 119, 167, 75, 39, 236, 207, 28, 173, 249, 27, 173, 14, 193, 225, 55, 131, 137, 22, 247, 184, 65, 44, 104, 145, 133, 183, 138, 180, 178, 127, 26, 20, 192, 14, 210 }, new byte[] { 87, 203, 55, 225, 10, 188, 236, 183, 66, 69, 42, 241, 56, 109, 80, 114, 41, 54, 124, 223, 104, 184, 141, 131, 40, 72, 242, 118, 137, 141, 136, 171, 38, 233, 103, 45, 86, 33, 145, 113, 239, 162, 86, 41, 245, 162, 142, 101, 247, 165, 250, 223, 117, 4, 77, 73, 59, 254, 84, 120, 167, 180, 1, 73, 143, 234, 160, 75, 202, 64, 25, 149, 65, 77, 119, 7, 8, 133, 124, 157, 171, 2, 149, 163, 48, 226, 75, 158, 120, 217, 17, 178, 143, 204, 182, 56, 29, 23, 255, 2, 221, 62, 129, 185, 213, 123, 63, 25, 232, 6, 206, 211, 172, 211, 185, 224, 200, 58, 232, 254, 142, 86, 184, 170, 83, 155, 198, 25 }, "Sindico", null },
                    { 4, null, null, null, "email@gmail.com", 3, "UsuarioMorador", new byte[] { 37, 216, 254, 13, 90, 64, 85, 175, 104, 222, 220, 64, 86, 228, 62, 68, 199, 21, 82, 58, 121, 120, 162, 23, 80, 42, 202, 213, 150, 119, 167, 75, 39, 236, 207, 28, 173, 249, 27, 173, 14, 193, 225, 55, 131, 137, 22, 247, 184, 65, 44, 104, 145, 133, 183, 138, 180, 178, 127, 26, 20, 192, 14, 210 }, new byte[] { 87, 203, 55, 225, 10, 188, 236, 183, 66, 69, 42, 241, 56, 109, 80, 114, 41, 54, 124, 223, 104, 184, 141, 131, 40, 72, 242, 118, 137, 141, 136, 171, 38, 233, 103, 45, 86, 33, 145, 113, 239, 162, 86, 41, 245, 162, 142, 101, 247, 165, 250, 223, 117, 4, 77, 73, 59, 254, 84, 120, 167, 180, 1, 73, 143, 234, 160, 75, 202, 64, 25, 149, 65, 77, 119, 7, 8, 133, 124, 157, 171, 2, 149, 163, 48, 226, 75, 158, 120, 217, 17, 178, 143, 204, 182, 56, 29, 23, 255, 2, 221, 62, 129, 185, 213, 123, 63, 25, 232, 6, 206, 211, 172, 211, 185, 224, 200, 58, 232, 254, 142, 86, 184, 170, 83, 155, 198, 25 }, "Morador", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartamentos_CondominioId",
                table: "Apartamentos",
                column: "CondominioId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartPessoas_ApartamentoId",
                table: "ApartPessoas",
                column: "ApartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartPessoas_PessoaId",
                table: "ApartPessoas",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Avisos_PessoaId",
                table: "Avisos",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Condominios_PortariaId",
                table: "Condominios",
                column: "PortariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependentes_PessoaId",
                table: "Dependentes",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_PessoaId",
                table: "Entregas",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_PortariaId",
                table: "Entregas",
                column: "PortariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_AreaComumId",
                table: "Reservas",
                column: "AreaComumId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_PessoaId",
                table: "Reservas",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ApartamentoId",
                table: "Usuarios",
                column: "ApartamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartPessoas");

            migrationBuilder.DropTable(
                name: "Avisos");

            migrationBuilder.DropTable(
                name: "Dependentes");

            migrationBuilder.DropTable(
                name: "Entregas");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "AreasComuns");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Apartamentos");

            migrationBuilder.DropTable(
                name: "Condominios");

            migrationBuilder.DropTable(
                name: "Portarias");
        }
    }
}
