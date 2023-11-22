using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CondominusApi.Migrations
{
    /// <inheritdoc />
    public partial class Parametros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartamentos_Usuarios_UsuarioId",
                table: "Apartamentos");

            migrationBuilder.DropIndex(
                name: "IX_Apartamentos_UsuarioId",
                table: "Apartamentos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Apartamentos");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Pessoas",
                newName: "Perfil");

            migrationBuilder.AddColumn<int>(
                name: "ApartamentoId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdApartamento",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdPessoa",
                table: "Dependentes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Entregas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataEntrega", "DataRetirada" },
                values: new object[] { new DateTime(2023, 11, 22, 11, 27, 47, 506, DateTimeKind.Local).AddTicks(4137), new DateTime(2023, 11, 22, 11, 27, 47, 506, DateTimeKind.Local).AddTicks(4149) });

            migrationBuilder.UpdateData(
                table: "Entregas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataEntrega", "DataRetirada" },
                values: new object[] { new DateTime(2023, 11, 22, 11, 27, 47, 506, DateTimeKind.Local).AddTicks(4150), new DateTime(2023, 11, 22, 11, 27, 47, 506, DateTimeKind.Local).AddTicks(4150) });

            migrationBuilder.UpdateData(
                table: "Entregas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DataEntrega", "DataRetirada" },
                values: new object[] { new DateTime(2023, 11, 22, 11, 27, 47, 506, DateTimeKind.Local).AddTicks(4151), new DateTime(2023, 11, 22, 11, 27, 47, 506, DateTimeKind.Local).AddTicks(4151) });

            migrationBuilder.UpdateData(
                table: "Entregas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DataEntrega", "DataRetirada" },
                values: new object[] { new DateTime(2023, 11, 22, 11, 27, 47, 506, DateTimeKind.Local).AddTicks(4152), new DateTime(2023, 11, 22, 11, 27, 47, 506, DateTimeKind.Local).AddTicks(4153) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApartamentoId", "Cpf", "IdApartamento", "PasswordHash", "PasswordSalt", "Telefone" },
                values: new object[] { null, null, 1, new byte[] { 179, 238, 253, 99, 253, 3, 65, 182, 110, 193, 77, 135, 36, 12, 83, 73, 91, 181, 82, 72, 69, 93, 180, 86, 30, 182, 229, 6, 66, 161, 35, 124, 89, 108, 107, 149, 9, 166, 70, 4, 113, 29, 105, 254, 91, 61, 5, 145, 134, 28, 174, 76, 19, 219, 245, 190, 88, 41, 187, 15, 171, 224, 189, 48 }, new byte[] { 133, 112, 13, 141, 172, 154, 3, 49, 159, 161, 76, 68, 31, 165, 10, 178, 167, 110, 96, 25, 102, 8, 126, 125, 141, 189, 63, 78, 199, 156, 119, 107, 158, 202, 30, 197, 91, 126, 79, 35, 210, 243, 120, 142, 153, 132, 222, 203, 160, 25, 113, 247, 66, 121, 154, 203, 30, 23, 24, 136, 219, 38, 71, 132, 28, 216, 116, 236, 228, 184, 153, 119, 79, 204, 184, 220, 125, 189, 210, 171, 86, 30, 252, 149, 65, 150, 37, 35, 229, 254, 177, 129, 60, 16, 138, 79, 148, 91, 109, 70, 39, 176, 193, 21, 217, 129, 82, 4, 76, 63, 134, 176, 160, 115, 102, 188, 124, 74, 72, 201, 165, 75, 118, 151, 179, 54, 196, 211 }, null });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ApartamentoId", "Cpf", "IdApartamento", "PasswordHash", "PasswordSalt", "Telefone" },
                values: new object[] { null, null, 2, new byte[] { 179, 238, 253, 99, 253, 3, 65, 182, 110, 193, 77, 135, 36, 12, 83, 73, 91, 181, 82, 72, 69, 93, 180, 86, 30, 182, 229, 6, 66, 161, 35, 124, 89, 108, 107, 149, 9, 166, 70, 4, 113, 29, 105, 254, 91, 61, 5, 145, 134, 28, 174, 76, 19, 219, 245, 190, 88, 41, 187, 15, 171, 224, 189, 48 }, new byte[] { 133, 112, 13, 141, 172, 154, 3, 49, 159, 161, 76, 68, 31, 165, 10, 178, 167, 110, 96, 25, 102, 8, 126, 125, 141, 189, 63, 78, 199, 156, 119, 107, 158, 202, 30, 197, 91, 126, 79, 35, 210, 243, 120, 142, 153, 132, 222, 203, 160, 25, 113, 247, 66, 121, 154, 203, 30, 23, 24, 136, 219, 38, 71, 132, 28, 216, 116, 236, 228, 184, 153, 119, 79, 204, 184, 220, 125, 189, 210, 171, 86, 30, 252, 149, 65, 150, 37, 35, 229, 254, 177, 129, 60, 16, 138, 79, 148, 91, 109, 70, 39, 176, 193, 21, 217, 129, 82, 4, 76, 63, 134, 176, 160, 115, 102, 188, 124, 74, 72, 201, 165, 75, 118, 151, 179, 54, 196, 211 }, null });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ApartamentoId", "Cpf", "IdApartamento", "PasswordHash", "PasswordSalt", "Telefone" },
                values: new object[] { null, null, 3, new byte[] { 179, 238, 253, 99, 253, 3, 65, 182, 110, 193, 77, 135, 36, 12, 83, 73, 91, 181, 82, 72, 69, 93, 180, 86, 30, 182, 229, 6, 66, 161, 35, 124, 89, 108, 107, 149, 9, 166, 70, 4, 113, 29, 105, 254, 91, 61, 5, 145, 134, 28, 174, 76, 19, 219, 245, 190, 88, 41, 187, 15, 171, 224, 189, 48 }, new byte[] { 133, 112, 13, 141, 172, 154, 3, 49, 159, 161, 76, 68, 31, 165, 10, 178, 167, 110, 96, 25, 102, 8, 126, 125, 141, 189, 63, 78, 199, 156, 119, 107, 158, 202, 30, 197, 91, 126, 79, 35, 210, 243, 120, 142, 153, 132, 222, 203, 160, 25, 113, 247, 66, 121, 154, 203, 30, 23, 24, 136, 219, 38, 71, 132, 28, 216, 116, 236, 228, 184, 153, 119, 79, 204, 184, 220, 125, 189, 210, 171, 86, 30, 252, 149, 65, 150, 37, 35, 229, 254, 177, 129, 60, 16, 138, 79, 148, 91, 109, 70, 39, 176, 193, 21, 217, 129, 82, 4, 76, 63, 134, 176, 160, 115, 102, 188, 124, 74, 72, 201, 165, 75, 118, 151, 179, 54, 196, 211 }, null });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ApartamentoId",
                table: "Usuarios",
                column: "ApartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Apartamentos_ApartamentoId",
                table: "Usuarios",
                column: "ApartamentoId",
                principalTable: "Apartamentos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Apartamentos_ApartamentoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_ApartamentoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ApartamentoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IdApartamento",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IdPessoa",
                table: "Dependentes");

            migrationBuilder.RenameColumn(
                name: "Perfil",
                table: "Pessoas",
                newName: "Tipo");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Apartamentos",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Apartamentos",
                keyColumn: "Id",
                keyValue: 1,
                column: "UsuarioId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Apartamentos",
                keyColumn: "Id",
                keyValue: 2,
                column: "UsuarioId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Apartamentos",
                keyColumn: "Id",
                keyValue: 3,
                column: "UsuarioId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Apartamentos",
                keyColumn: "Id",
                keyValue: 4,
                column: "UsuarioId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Entregas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataEntrega", "DataRetirada" },
                values: new object[] { new DateTime(2023, 10, 24, 22, 11, 26, 398, DateTimeKind.Local).AddTicks(8456), new DateTime(2023, 10, 24, 22, 11, 26, 398, DateTimeKind.Local).AddTicks(8465) });

            migrationBuilder.UpdateData(
                table: "Entregas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataEntrega", "DataRetirada" },
                values: new object[] { new DateTime(2023, 10, 24, 22, 11, 26, 398, DateTimeKind.Local).AddTicks(8467), new DateTime(2023, 10, 24, 22, 11, 26, 398, DateTimeKind.Local).AddTicks(8467) });

            migrationBuilder.UpdateData(
                table: "Entregas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DataEntrega", "DataRetirada" },
                values: new object[] { new DateTime(2023, 10, 24, 22, 11, 26, 398, DateTimeKind.Local).AddTicks(8468), new DateTime(2023, 10, 24, 22, 11, 26, 398, DateTimeKind.Local).AddTicks(8469) });

            migrationBuilder.UpdateData(
                table: "Entregas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DataEntrega", "DataRetirada" },
                values: new object[] { new DateTime(2023, 10, 24, 22, 11, 26, 398, DateTimeKind.Local).AddTicks(8470), new DateTime(2023, 10, 24, 22, 11, 26, 398, DateTimeKind.Local).AddTicks(8470) });

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
                name: "IX_Apartamentos_UsuarioId",
                table: "Apartamentos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartamentos_Usuarios_UsuarioId",
                table: "Apartamentos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
