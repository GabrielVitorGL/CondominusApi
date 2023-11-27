using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CondominusApi.Migrations
{
    /// <inheritdoc />
    public partial class Metodos : Migration
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
                    IdApartamento = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "ApartPessoas",
                columns: table => new
                {
                    IdApartamento = table.Column<int>(type: "int", nullable: false),
                    IdPessoa = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartPessoas", x => new { x.IdPessoa, x.IdApartamento });
                    table.ForeignKey(
                        name: "FK_ApartPessoas_Apartamentos_IdApartamento",
                        column: x => x.IdApartamento,
                        principalTable: "Apartamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApartPessoas_Pessoas_IdPessoa",
                        column: x => x.IdPessoa,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApartPessoas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
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
                    IdApartamento = table.Column<int>(type: "int", nullable: false)
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
                columns: new[] { "Id", "Cpf", "DataAcesso", "Email", "IdApartamento", "Nome", "PasswordHash", "PasswordSalt", "Perfil", "Telefone" },
                values: new object[,]
                {
                    { 1, null, null, "admin@gmail.com", 1, "UsuarioAdmin", new byte[] { 123, 86, 211, 111, 73, 218, 39, 44, 171, 229, 182, 183, 199, 126, 50, 135, 19, 78, 148, 157, 31, 142, 226, 196, 172, 253, 11, 106, 52, 50, 227, 99, 109, 252, 185, 224, 20, 18, 203, 176, 48, 181, 80, 116, 210, 195, 236, 208, 254, 170, 239, 120, 61, 205, 88, 138, 161, 198, 113, 55, 200, 143, 139, 175 }, new byte[] { 234, 190, 179, 79, 211, 53, 203, 165, 109, 70, 115, 85, 193, 149, 203, 143, 161, 217, 139, 97, 146, 23, 58, 51, 233, 196, 58, 193, 219, 84, 11, 21, 89, 243, 61, 169, 125, 108, 193, 45, 199, 38, 11, 140, 119, 18, 167, 69, 118, 172, 178, 228, 150, 176, 144, 153, 71, 95, 14, 84, 116, 160, 227, 151, 215, 0, 72, 32, 41, 61, 187, 172, 125, 234, 208, 11, 82, 158, 14, 165, 67, 114, 83, 11, 133, 50, 34, 175, 186, 253, 247, 86, 206, 64, 255, 133, 186, 162, 12, 252, 12, 61, 186, 200, 95, 177, 50, 85, 24, 244, 181, 77, 154, 165, 147, 184, 21, 158, 157, 249, 240, 78, 254, 25, 200, 41, 237, 77 }, "Admin", null },
                    { 3, null, null, "UsuarioSindico@gmail.com", 2, "UsuarioSindico", new byte[] { 123, 86, 211, 111, 73, 218, 39, 44, 171, 229, 182, 183, 199, 126, 50, 135, 19, 78, 148, 157, 31, 142, 226, 196, 172, 253, 11, 106, 52, 50, 227, 99, 109, 252, 185, 224, 20, 18, 203, 176, 48, 181, 80, 116, 210, 195, 236, 208, 254, 170, 239, 120, 61, 205, 88, 138, 161, 198, 113, 55, 200, 143, 139, 175 }, new byte[] { 234, 190, 179, 79, 211, 53, 203, 165, 109, 70, 115, 85, 193, 149, 203, 143, 161, 217, 139, 97, 146, 23, 58, 51, 233, 196, 58, 193, 219, 84, 11, 21, 89, 243, 61, 169, 125, 108, 193, 45, 199, 38, 11, 140, 119, 18, 167, 69, 118, 172, 178, 228, 150, 176, 144, 153, 71, 95, 14, 84, 116, 160, 227, 151, 215, 0, 72, 32, 41, 61, 187, 172, 125, 234, 208, 11, 82, 158, 14, 165, 67, 114, 83, 11, 133, 50, 34, 175, 186, 253, 247, 86, 206, 64, 255, 133, 186, 162, 12, 252, 12, 61, 186, 200, 95, 177, 50, 85, 24, 244, 181, 77, 154, 165, 147, 184, 21, 158, 157, 249, 240, 78, 254, 25, 200, 41, 237, 77 }, "Sindico", null },
                    { 4, null, null, "UsuarioMorador@gmail.com", 3, "UsuarioMorador", new byte[] { 123, 86, 211, 111, 73, 218, 39, 44, 171, 229, 182, 183, 199, 126, 50, 135, 19, 78, 148, 157, 31, 142, 226, 196, 172, 253, 11, 106, 52, 50, 227, 99, 109, 252, 185, 224, 20, 18, 203, 176, 48, 181, 80, 116, 210, 195, 236, 208, 254, 170, 239, 120, 61, 205, 88, 138, 161, 198, 113, 55, 200, 143, 139, 175 }, new byte[] { 234, 190, 179, 79, 211, 53, 203, 165, 109, 70, 115, 85, 193, 149, 203, 143, 161, 217, 139, 97, 146, 23, 58, 51, 233, 196, 58, 193, 219, 84, 11, 21, 89, 243, 61, 169, 125, 108, 193, 45, 199, 38, 11, 140, 119, 18, 167, 69, 118, 172, 178, 228, 150, 176, 144, 153, 71, 95, 14, 84, 116, 160, 227, 151, 215, 0, 72, 32, 41, 61, 187, 172, 125, 234, 208, 11, 82, 158, 14, 165, 67, 114, 83, 11, 133, 50, 34, 175, 186, 253, 247, 86, 206, 64, 255, 133, 186, 162, 12, 252, 12, 61, 186, 200, 95, 177, 50, 85, 24, 244, 181, 77, 154, 165, 147, 184, 21, 158, 157, 249, 240, 78, 254, 25, 200, 41, 237, 77 }, "Morador", null }
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
                columns: new[] { "Id", "DataEntrega", "DataRetirada", "Destinatario", "IdApartamento" },
                values: new object[] { 1, null, null, "Joao Guilherme", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Apartamentos_IdCondominio",
                table: "Apartamentos",
                column: "IdCondominio");

            migrationBuilder.CreateIndex(
                name: "IX_ApartPessoas_IdApartamento",
                table: "ApartPessoas",
                column: "IdApartamento");

            migrationBuilder.CreateIndex(
                name: "IX_ApartPessoas_UsuarioId",
                table: "ApartPessoas",
                column: "UsuarioId");

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
                name: "Apartamentos");

            migrationBuilder.DropTable(
                name: "AreasComuns");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Condominios");
        }
    }
}
