using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CondominusApi.Migrations
{
    /// <inheritdoc />
    public partial class @base : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Apartamentos_ApartamentoId",
                table: "Pessoas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Condominios_CondominioId",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_ApartamentoId",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_CondominioId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "ApartamentoId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "CondominioId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "IdApartamento",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "IdCondominio",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Perfil",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AreasComuns");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Apartamentos");

            migrationBuilder.RenameColumn(
                name: "DataReserva",
                table: "Reservas",
                newName: "Data");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Pessoas",
                newName: "Tipo");

            migrationBuilder.AddColumn<int>(
                name: "PortariaId",
                table: "Entregas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdPortaria",
                table: "Condominios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PortariaId",
                table: "Condominios",
                type: "int",
                nullable: true);

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
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PessoaId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.UpdateData(
                table: "Condominios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IdPortaria", "PortariaId" },
                values: new object[] { 0, null });

            migrationBuilder.UpdateData(
                table: "Condominios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IdPortaria", "PortariaId" },
                values: new object[] { 0, null });

            migrationBuilder.UpdateData(
                table: "Condominios",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IdPortaria", "PortariaId" },
                values: new object[] { 0, null });

            migrationBuilder.UpdateData(
                table: "Condominios",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IdPortaria", "PortariaId" },
                values: new object[] { 0, null });

            migrationBuilder.UpdateData(
                table: "Entregas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataEntrega", "DataRetirada", "PortariaId" },
                values: new object[] { new DateTime(2023, 10, 24, 22, 11, 26, 398, DateTimeKind.Local).AddTicks(8456), new DateTime(2023, 10, 24, 22, 11, 26, 398, DateTimeKind.Local).AddTicks(8465), null });

            migrationBuilder.UpdateData(
                table: "Entregas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataEntrega", "DataRetirada", "PortariaId" },
                values: new object[] { new DateTime(2023, 10, 24, 22, 11, 26, 398, DateTimeKind.Local).AddTicks(8467), new DateTime(2023, 10, 24, 22, 11, 26, 398, DateTimeKind.Local).AddTicks(8467), null });

            migrationBuilder.UpdateData(
                table: "Entregas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DataEntrega", "DataRetirada", "PortariaId" },
                values: new object[] { new DateTime(2023, 10, 24, 22, 11, 26, 398, DateTimeKind.Local).AddTicks(8468), new DateTime(2023, 10, 24, 22, 11, 26, 398, DateTimeKind.Local).AddTicks(8469), null });

            migrationBuilder.UpdateData(
                table: "Entregas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DataEntrega", "DataRetirada", "PortariaId" },
                values: new object[] { new DateTime(2023, 10, 24, 22, 11, 26, 398, DateTimeKind.Local).AddTicks(8470), new DateTime(2023, 10, 24, 22, 11, 26, 398, DateTimeKind.Local).AddTicks(8470), null });

            migrationBuilder.UpdateData(
                table: "Reservas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Data",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Reservas",
                keyColumn: "Id",
                keyValue: 2,
                column: "Data",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Reservas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Data",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Reservas",
                keyColumn: "Id",
                keyValue: 4,
                column: "Data",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 151, 49, 231, 172, 140, 246, 26, 165, 92, 101, 233, 102, 60, 37, 230, 163, 190, 194, 49, 238, 125, 13, 242, 85, 82, 34, 51, 63, 1, 86, 67, 252, 208, 199, 67, 144, 187, 166, 235, 244, 2, 205, 118, 204, 120, 80, 156, 199, 85, 93, 25, 110, 71, 53, 194, 25, 25, 86, 205, 180, 246, 13, 5, 78 }, new byte[] { 213, 82, 207, 244, 102, 2, 120, 199, 121, 23, 145, 87, 100, 237, 112, 62, 108, 75, 189, 192, 195, 98, 37, 177, 218, 90, 116, 99, 100, 117, 47, 244, 32, 254, 154, 186, 228, 246, 254, 139, 26, 205, 24, 138, 225, 189, 132, 217, 117, 230, 179, 212, 41, 185, 68, 4, 48, 79, 199, 171, 5, 144, 72, 120, 36, 131, 82, 10, 239, 122, 239, 200, 195, 136, 98, 251, 11, 98, 107, 194, 114, 79, 50, 24, 66, 155, 200, 200, 10, 121, 71, 39, 232, 1, 45, 68, 101, 53, 164, 229, 164, 40, 131, 163, 191, 162, 42, 208, 68, 11, 49, 168, 36, 220, 76, 217, 239, 254, 158, 125, 245, 171, 244, 113, 233, 212, 48, 176 } });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 151, 49, 231, 172, 140, 246, 26, 165, 92, 101, 233, 102, 60, 37, 230, 163, 190, 194, 49, 238, 125, 13, 242, 85, 82, 34, 51, 63, 1, 86, 67, 252, 208, 199, 67, 144, 187, 166, 235, 244, 2, 205, 118, 204, 120, 80, 156, 199, 85, 93, 25, 110, 71, 53, 194, 25, 25, 86, 205, 180, 246, 13, 5, 78 }, new byte[] { 213, 82, 207, 244, 102, 2, 120, 199, 121, 23, 145, 87, 100, 237, 112, 62, 108, 75, 189, 192, 195, 98, 37, 177, 218, 90, 116, 99, 100, 117, 47, 244, 32, 254, 154, 186, 228, 246, 254, 139, 26, 205, 24, 138, 225, 189, 132, 217, 117, 230, 179, 212, 41, 185, 68, 4, 48, 79, 199, 171, 5, 144, 72, 120, 36, 131, 82, 10, 239, 122, 239, 200, 195, 136, 98, 251, 11, 98, 107, 194, 114, 79, 50, 24, 66, 155, 200, 200, 10, 121, 71, 39, 232, 1, 45, 68, 101, 53, 164, 229, 164, 40, 131, 163, 191, 162, 42, 208, 68, 11, 49, 168, 36, 220, 76, 217, 239, 254, 158, 125, 245, 171, 244, 113, 233, 212, 48, 176 } });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 151, 49, 231, 172, 140, 246, 26, 165, 92, 101, 233, 102, 60, 37, 230, 163, 190, 194, 49, 238, 125, 13, 242, 85, 82, 34, 51, 63, 1, 86, 67, 252, 208, 199, 67, 144, 187, 166, 235, 244, 2, 205, 118, 204, 120, 80, 156, 199, 85, 93, 25, 110, 71, 53, 194, 25, 25, 86, 205, 180, 246, 13, 5, 78 }, new byte[] { 213, 82, 207, 244, 102, 2, 120, 199, 121, 23, 145, 87, 100, 237, 112, 62, 108, 75, 189, 192, 195, 98, 37, 177, 218, 90, 116, 99, 100, 117, 47, 244, 32, 254, 154, 186, 228, 246, 254, 139, 26, 205, 24, 138, 225, 189, 132, 217, 117, 230, 179, 212, 41, 185, 68, 4, 48, 79, 199, 171, 5, 144, 72, 120, 36, 131, 82, 10, 239, 122, 239, 200, 195, 136, 98, 251, 11, 98, 107, 194, 114, 79, 50, 24, 66, 155, 200, 200, 10, 121, 71, 39, 232, 1, 45, 68, 101, 53, 164, 229, 164, 40, 131, 163, 191, 162, 42, 208, 68, 11, 49, 168, 36, 220, 76, 217, 239, 254, 158, 125, 245, 171, 244, 113, 233, 212, 48, 176 } });

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_PortariaId",
                table: "Entregas",
                column: "PortariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Condominios_PortariaId",
                table: "Condominios",
                column: "PortariaId");

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
                name: "IX_Dependentes_PessoaId",
                table: "Dependentes",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Condominios_Portarias_PortariaId",
                table: "Condominios",
                column: "PortariaId",
                principalTable: "Portarias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entregas_Portarias_PortariaId",
                table: "Entregas",
                column: "PortariaId",
                principalTable: "Portarias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Condominios_Portarias_PortariaId",
                table: "Condominios");

            migrationBuilder.DropForeignKey(
                name: "FK_Entregas_Portarias_PortariaId",
                table: "Entregas");

            migrationBuilder.DropTable(
                name: "ApartPessoas");

            migrationBuilder.DropTable(
                name: "Avisos");

            migrationBuilder.DropTable(
                name: "Dependentes");

            migrationBuilder.DropTable(
                name: "Portarias");

            migrationBuilder.DropIndex(
                name: "IX_Entregas_PortariaId",
                table: "Entregas");

            migrationBuilder.DropIndex(
                name: "IX_Condominios_PortariaId",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "PortariaId",
                table: "Entregas");

            migrationBuilder.DropColumn(
                name: "IdPortaria",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "PortariaId",
                table: "Condominios");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Reservas",
                newName: "DataReserva");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Pessoas",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApartamentoId",
                table: "Pessoas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CondominioId",
                table: "Pessoas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdApartamento",
                table: "Pessoas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCondominio",
                table: "Pessoas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Perfil",
                table: "Pessoas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "AreasComuns",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Apartamentos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Apartamentos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: null);

            migrationBuilder.UpdateData(
                table: "Apartamentos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: null);

            migrationBuilder.UpdateData(
                table: "Apartamentos",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: null);

            migrationBuilder.UpdateData(
                table: "Apartamentos",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: null);

            migrationBuilder.UpdateData(
                table: "AreasComuns",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: null);

            migrationBuilder.UpdateData(
                table: "AreasComuns",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: null);

            migrationBuilder.UpdateData(
                table: "AreasComuns",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: null);

            migrationBuilder.UpdateData(
                table: "AreasComuns",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: null);

            migrationBuilder.UpdateData(
                table: "Entregas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataEntrega", "DataRetirada" },
                values: new object[] { new DateTime(2023, 9, 23, 12, 35, 48, 541, DateTimeKind.Local).AddTicks(976), new DateTime(2023, 9, 23, 12, 35, 48, 541, DateTimeKind.Local).AddTicks(987) });

            migrationBuilder.UpdateData(
                table: "Entregas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataEntrega", "DataRetirada" },
                values: new object[] { new DateTime(2023, 9, 23, 12, 35, 48, 541, DateTimeKind.Local).AddTicks(988), new DateTime(2023, 9, 23, 12, 35, 48, 541, DateTimeKind.Local).AddTicks(989) });

            migrationBuilder.UpdateData(
                table: "Entregas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DataEntrega", "DataRetirada" },
                values: new object[] { new DateTime(2023, 9, 23, 12, 35, 48, 541, DateTimeKind.Local).AddTicks(990), new DateTime(2023, 9, 23, 12, 35, 48, 541, DateTimeKind.Local).AddTicks(990) });

            migrationBuilder.UpdateData(
                table: "Entregas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DataEntrega", "DataRetirada" },
                values: new object[] { new DateTime(2023, 9, 23, 12, 35, 48, 541, DateTimeKind.Local).AddTicks(991), new DateTime(2023, 9, 23, 12, 35, 48, 541, DateTimeKind.Local).AddTicks(992) });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApartamentoId", "CondominioId", "IdApartamento", "IdCondominio", "Perfil" },
                values: new object[] { null, null, 0, 0, null });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ApartamentoId", "CondominioId", "IdApartamento", "IdCondominio", "Perfil" },
                values: new object[] { null, null, 0, 0, null });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ApartamentoId", "CondominioId", "IdApartamento", "IdCondominio", "Perfil" },
                values: new object[] { null, null, 0, 0, null });

            migrationBuilder.UpdateData(
                table: "Pessoas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ApartamentoId", "CondominioId", "IdApartamento", "IdCondominio", "Perfil" },
                values: new object[] { null, null, 0, 0, null });

            migrationBuilder.UpdateData(
                table: "Reservas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataReserva", "Status" },
                values: new object[] { new DateTime(2023, 9, 23, 12, 35, 48, 541, DateTimeKind.Local).AddTicks(1025), null });

            migrationBuilder.UpdateData(
                table: "Reservas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataReserva", "Status" },
                values: new object[] { new DateTime(2023, 9, 23, 12, 35, 48, 541, DateTimeKind.Local).AddTicks(1026), null });

            migrationBuilder.UpdateData(
                table: "Reservas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DataReserva", "Status" },
                values: new object[] { new DateTime(2023, 9, 23, 12, 35, 48, 541, DateTimeKind.Local).AddTicks(1027), null });

            migrationBuilder.UpdateData(
                table: "Reservas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DataReserva", "Status" },
                values: new object[] { new DateTime(2023, 9, 23, 12, 35, 48, 541, DateTimeKind.Local).AddTicks(1028), null });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 157, 142, 237, 117, 236, 151, 56, 133, 167, 218, 252, 90, 28, 217, 229, 122, 210, 204, 148, 144, 117, 248, 206, 208, 10, 12, 172, 52, 115, 235, 91, 135, 13, 118, 30, 239, 116, 159, 242, 57, 253, 140, 16, 141, 72, 135, 76, 47, 87, 251, 63, 26, 125, 193, 168, 29, 154, 216, 206, 72, 46, 205, 80, 76 }, new byte[] { 89, 151, 151, 250, 180, 108, 212, 72, 124, 202, 251, 253, 165, 247, 4, 173, 47, 83, 106, 193, 214, 183, 116, 252, 213, 173, 37, 154, 123, 24, 191, 160, 134, 12, 74, 14, 153, 225, 109, 119, 53, 80, 22, 129, 136, 3, 169, 86, 74, 134, 222, 249, 71, 231, 94, 41, 252, 243, 46, 163, 174, 226, 43, 195, 89, 148, 165, 160, 89, 21, 29, 255, 173, 183, 207, 104, 161, 2, 164, 236, 12, 153, 153, 204, 122, 16, 42, 86, 232, 2, 149, 69, 59, 20, 132, 41, 183, 65, 219, 190, 59, 205, 103, 91, 53, 32, 201, 203, 101, 254, 28, 165, 228, 186, 218, 205, 244, 96, 229, 249, 218, 236, 160, 41, 189, 203, 236, 12 } });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 157, 142, 237, 117, 236, 151, 56, 133, 167, 218, 252, 90, 28, 217, 229, 122, 210, 204, 148, 144, 117, 248, 206, 208, 10, 12, 172, 52, 115, 235, 91, 135, 13, 118, 30, 239, 116, 159, 242, 57, 253, 140, 16, 141, 72, 135, 76, 47, 87, 251, 63, 26, 125, 193, 168, 29, 154, 216, 206, 72, 46, 205, 80, 76 }, new byte[] { 89, 151, 151, 250, 180, 108, 212, 72, 124, 202, 251, 253, 165, 247, 4, 173, 47, 83, 106, 193, 214, 183, 116, 252, 213, 173, 37, 154, 123, 24, 191, 160, 134, 12, 74, 14, 153, 225, 109, 119, 53, 80, 22, 129, 136, 3, 169, 86, 74, 134, 222, 249, 71, 231, 94, 41, 252, 243, 46, 163, 174, 226, 43, 195, 89, 148, 165, 160, 89, 21, 29, 255, 173, 183, 207, 104, 161, 2, 164, 236, 12, 153, 153, 204, 122, 16, 42, 86, 232, 2, 149, 69, 59, 20, 132, 41, 183, 65, 219, 190, 59, 205, 103, 91, 53, 32, 201, 203, 101, 254, 28, 165, 228, 186, 218, 205, 244, 96, 229, 249, 218, 236, 160, 41, 189, 203, 236, 12 } });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 157, 142, 237, 117, 236, 151, 56, 133, 167, 218, 252, 90, 28, 217, 229, 122, 210, 204, 148, 144, 117, 248, 206, 208, 10, 12, 172, 52, 115, 235, 91, 135, 13, 118, 30, 239, 116, 159, 242, 57, 253, 140, 16, 141, 72, 135, 76, 47, 87, 251, 63, 26, 125, 193, 168, 29, 154, 216, 206, 72, 46, 205, 80, 76 }, new byte[] { 89, 151, 151, 250, 180, 108, 212, 72, 124, 202, 251, 253, 165, 247, 4, 173, 47, 83, 106, 193, 214, 183, 116, 252, 213, 173, 37, 154, 123, 24, 191, 160, 134, 12, 74, 14, 153, 225, 109, 119, 53, 80, 22, 129, 136, 3, 169, 86, 74, 134, 222, 249, 71, 231, 94, 41, 252, 243, 46, 163, 174, 226, 43, 195, 89, 148, 165, 160, 89, 21, 29, 255, 173, 183, 207, 104, 161, 2, 164, 236, 12, 153, 153, 204, 122, 16, 42, 86, 232, 2, 149, 69, 59, 20, 132, 41, 183, 65, 219, 190, 59, 205, 103, 91, 53, 32, 201, 203, 101, 254, 28, 165, 228, 186, 218, 205, 244, 96, 229, 249, 218, 236, 160, 41, 189, 203, 236, 12 } });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_ApartamentoId",
                table: "Pessoas",
                column: "ApartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_CondominioId",
                table: "Pessoas",
                column: "CondominioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Apartamentos_ApartamentoId",
                table: "Pessoas",
                column: "ApartamentoId",
                principalTable: "Apartamentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Condominios_CondominioId",
                table: "Pessoas",
                column: "CondominioId",
                principalTable: "Condominios",
                principalColumn: "Id");
        }
    }
}
