using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CondominusApi.Migrations
{
    /// <inheritdoc />
    public partial class Added : Migration
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
                name: "Apartamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCondominio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartamentos_Condominios_IdCondominio",
                        column: x => x.IdCondominio,
                        principalTable: "Condominios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entregas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destinatario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataEntrega = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataRetirada = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdApartamento = table.Column<int>(type: "int", nullable: false),
                    PortariaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entregas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entregas_Apartamentos_IdApartamento",
                        column: x => x.IdApartamento,
                        principalTable: "Apartamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entregas_Portarias_PortariaId",
                        column: x => x.PortariaId,
                        principalTable: "Portarias",
                        principalColumn: "Id");
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
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApartamentoId = table.Column<int>(type: "int", nullable: true),
                    IdApartamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoas_Apartamentos_ApartamentoId",
                        column: x => x.ApartamentoId,
                        principalTable: "Apartamentos",
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
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdPessoa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dependentes_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "Pessoas",
                columns: new[] { "Id", "ApartamentoId", "Cpf", "IdApartamento", "Nome", "Perfil", "Telefone" },
                values: new object[,]
                {
                    { 1, null, "56751898901", 0, "João Gomes", null, "11924316523" },
                    { 2, null, "63158658205", 0, "Paola Oliveira", null, "11975231678" },
                    { 3, null, "27458823908", 0, "Marilia Mendonça", null, "11937512056" },
                    { 4, null, "32152898910", 0, "Sorriso Maroto", null, "11987618735" }
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
                    { 1, null, null, null, "admin@gmail.com", 1, "UsuarioAdmin", new byte[] { 59, 181, 203, 66, 98, 231, 208, 217, 117, 219, 70, 237, 92, 65, 145, 6, 22, 104, 194, 168, 52, 227, 35, 253, 44, 208, 63, 122, 143, 196, 179, 128, 65, 228, 125, 116, 19, 213, 90, 191, 132, 13, 2, 54, 159, 174, 49, 183, 158, 252, 146, 16, 234, 178, 83, 186, 212, 12, 93, 233, 94, 78, 38, 60 }, new byte[] { 249, 215, 208, 74, 252, 93, 214, 55, 160, 151, 118, 150, 56, 251, 114, 248, 81, 155, 50, 137, 193, 120, 225, 92, 245, 210, 89, 193, 23, 86, 131, 43, 213, 113, 171, 116, 39, 232, 1, 193, 118, 48, 255, 142, 16, 23, 36, 128, 122, 218, 157, 13, 29, 153, 190, 193, 242, 195, 151, 9, 99, 108, 106, 96, 79, 45, 76, 162, 104, 254, 5, 116, 2, 31, 133, 8, 19, 147, 206, 190, 250, 205, 127, 243, 44, 222, 114, 38, 24, 12, 47, 72, 8, 36, 3, 58, 86, 29, 81, 141, 47, 168, 201, 91, 148, 137, 71, 255, 179, 85, 20, 159, 96, 224, 12, 104, 13, 135, 168, 188, 193, 90, 41, 243, 255, 79, 90, 103 }, "Admin", null },
                    { 3, null, null, null, "UsuarioSindico@gmail.com", 2, "UsuarioSindico", new byte[] { 59, 181, 203, 66, 98, 231, 208, 217, 117, 219, 70, 237, 92, 65, 145, 6, 22, 104, 194, 168, 52, 227, 35, 253, 44, 208, 63, 122, 143, 196, 179, 128, 65, 228, 125, 116, 19, 213, 90, 191, 132, 13, 2, 54, 159, 174, 49, 183, 158, 252, 146, 16, 234, 178, 83, 186, 212, 12, 93, 233, 94, 78, 38, 60 }, new byte[] { 249, 215, 208, 74, 252, 93, 214, 55, 160, 151, 118, 150, 56, 251, 114, 248, 81, 155, 50, 137, 193, 120, 225, 92, 245, 210, 89, 193, 23, 86, 131, 43, 213, 113, 171, 116, 39, 232, 1, 193, 118, 48, 255, 142, 16, 23, 36, 128, 122, 218, 157, 13, 29, 153, 190, 193, 242, 195, 151, 9, 99, 108, 106, 96, 79, 45, 76, 162, 104, 254, 5, 116, 2, 31, 133, 8, 19, 147, 206, 190, 250, 205, 127, 243, 44, 222, 114, 38, 24, 12, 47, 72, 8, 36, 3, 58, 86, 29, 81, 141, 47, 168, 201, 91, 148, 137, 71, 255, 179, 85, 20, 159, 96, 224, 12, 104, 13, 135, 168, 188, 193, 90, 41, 243, 255, 79, 90, 103 }, "Sindico", null },
                    { 4, null, null, null, "UsuarioMorador@gmail.com", 3, "UsuarioMorador", new byte[] { 59, 181, 203, 66, 98, 231, 208, 217, 117, 219, 70, 237, 92, 65, 145, 6, 22, 104, 194, 168, 52, 227, 35, 253, 44, 208, 63, 122, 143, 196, 179, 128, 65, 228, 125, 116, 19, 213, 90, 191, 132, 13, 2, 54, 159, 174, 49, 183, 158, 252, 146, 16, 234, 178, 83, 186, 212, 12, 93, 233, 94, 78, 38, 60 }, new byte[] { 249, 215, 208, 74, 252, 93, 214, 55, 160, 151, 118, 150, 56, 251, 114, 248, 81, 155, 50, 137, 193, 120, 225, 92, 245, 210, 89, 193, 23, 86, 131, 43, 213, 113, 171, 116, 39, 232, 1, 193, 118, 48, 255, 142, 16, 23, 36, 128, 122, 218, 157, 13, 29, 153, 190, 193, 242, 195, 151, 9, 99, 108, 106, 96, 79, 45, 76, 162, 104, 254, 5, 116, 2, 31, 133, 8, 19, 147, 206, 190, 250, 205, 127, 243, 44, 222, 114, 38, 24, 12, 47, 72, 8, 36, 3, 58, 86, 29, 81, 141, 47, 168, 201, 91, 148, 137, 71, 255, 179, 85, 20, 159, 96, 224, 12, 104, 13, 135, 168, 188, 193, 90, 41, 243, 255, 79, 90, 103 }, "Morador", null }
                });

            migrationBuilder.InsertData(
                table: "Apartamentos",
                columns: new[] { "Id", "IdCondominio", "Numero", "Telefone" },
                values: new object[,]
                {
                    { 1, 1, "A001", "11912345678" },
                    { 2, 1, "B002", "11912345678" },
                    { 3, 1, "C003", "11887654321" },
                    { 4, 1, "E005", "11955555555" }
                });

            migrationBuilder.InsertData(
                table: "Dependentes",
                columns: new[] { "Id", "IdPessoa", "Nome", "Telefone" },
                values: new object[,]
                {
                    { 1, 1, "João Gomes", "11924316523" },
                    { 2, 1, "Maria Silva", "11876543210" },
                    { 3, 2, "Carlos Oliveira", "11234567890" },
                    { 4, 3, "Ana Souza", "11987654321" },
                    { 5, 3, "Pedro Santos", "11765432109" }
                });

            migrationBuilder.InsertData(
                table: "Entregas",
                columns: new[] { "Id", "DataEntrega", "DataRetirada", "Destinatario", "IdApartamento", "PortariaId" },
                values: new object[] { 1, null, null, "Joao Guilherme", 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_Apartamentos_IdCondominio",
                table: "Apartamentos",
                column: "IdCondominio");

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
                name: "IX_Dependentes_IdPessoa",
                table: "Dependentes",
                column: "IdPessoa");

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_IdApartamento",
                table: "Entregas",
                column: "IdApartamento");

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_PortariaId",
                table: "Entregas",
                column: "PortariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_ApartamentoId",
                table: "Pessoas",
                column: "ApartamentoId");

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
                name: "Portarias");

            migrationBuilder.DropTable(
                name: "AreasComuns");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Apartamentos");

            migrationBuilder.DropTable(
                name: "Condominios");
        }
    }
}
