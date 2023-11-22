﻿// <auto-generated />
using System;
using CondominusApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CondominusApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231122142747_Parametros")]
    partial class Parametros
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CondominusApi.Models.ApartPessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApartamentoId")
                        .HasColumnType("int");

                    b.Property<int>("IdApartamento")
                        .HasColumnType("int");

                    b.Property<int>("IdPessoa")
                        .HasColumnType("int");

                    b.Property<int?>("PessoaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApartamentoId");

                    b.HasIndex("PessoaId");

                    b.ToTable("ApartPessoas");
                });

            modelBuilder.Entity("CondominusApi.Models.Apartamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CondominioId")
                        .HasColumnType("int");

                    b.Property<int>("IdCondominio")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CondominioId");

                    b.ToTable("Apartamentos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdCondominio = 0,
                            Numero = "A001",
                            Telefone = "11912345678"
                        },
                        new
                        {
                            Id = 2,
                            IdCondominio = 0,
                            Numero = "B002",
                            Telefone = "11912345678"
                        },
                        new
                        {
                            Id = 3,
                            IdCondominio = 0,
                            Numero = "C003",
                            Telefone = "11887654321"
                        },
                        new
                        {
                            Id = 4,
                            IdCondominio = 0,
                            Numero = "E005",
                            Telefone = "11955555555"
                        });
                });

            modelBuilder.Entity("CondominusApi.Models.AreaComum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacidade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AreasComuns");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacidade = 50,
                            Nome = "Salão de Festas"
                        },
                        new
                        {
                            Id = 2,
                            Capacidade = 30,
                            Nome = "Churrasqueira"
                        },
                        new
                        {
                            Id = 3,
                            Capacidade = 20,
                            Nome = "Sala de Jogos"
                        },
                        new
                        {
                            Id = 4,
                            Capacidade = 10,
                            Nome = "Piscina"
                        });
                });

            modelBuilder.Entity("CondominusApi.Models.Aviso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Assunto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataEnvio")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPessoa")
                        .HasColumnType("int");

                    b.Property<string>("Mensagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PessoaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Avisos");
                });

            modelBuilder.Entity("CondominusApi.Models.Condominio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPortaria")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PortariaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PortariaId");

                    b.ToTable("Condominios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Endereco = "Rua Guaranésia, 1070",
                            IdPortaria = 0,
                            Nome = "Vila Nova Maria"
                        },
                        new
                        {
                            Id = 2,
                            Endereco = "Rua Paulo Andrighetti, 1573",
                            IdPortaria = 0,
                            Nome = "Condomínio Aquarella Pari Colore"
                        },
                        new
                        {
                            Id = 3,
                            Endereco = "Rua Paulo Andrighetti, 449",
                            IdPortaria = 0,
                            Nome = "Condomínio Edifício Antônio Walter Santiago"
                        },
                        new
                        {
                            Id = 4,
                            Endereco = "Rua Eugênio de Freitas, 525",
                            IdPortaria = 0,
                            Nome = "Condomínio Edifício Veneza"
                        });
                });

            modelBuilder.Entity("CondominusApi.Models.Dependente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdPessoa")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PessoaId")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Dependentes");
                });

            modelBuilder.Entity("CondominusApi.Models.Entrega", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataEntrega")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataRetirada")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPessoa")
                        .HasColumnType("int");

                    b.Property<int?>("PessoaId")
                        .HasColumnType("int");

                    b.Property<int?>("PortariaId")
                        .HasColumnType("int");

                    b.Property<string>("Remetente")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.HasIndex("PortariaId");

                    b.ToTable("Entregas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataEntrega = new DateTime(2023, 11, 22, 11, 27, 47, 506, DateTimeKind.Local).AddTicks(4137),
                            DataRetirada = new DateTime(2023, 11, 22, 11, 27, 47, 506, DateTimeKind.Local).AddTicks(4149),
                            IdPessoa = 0,
                            Remetente = "Sorriso Maroto"
                        },
                        new
                        {
                            Id = 2,
                            DataEntrega = new DateTime(2023, 11, 22, 11, 27, 47, 506, DateTimeKind.Local).AddTicks(4150),
                            DataRetirada = new DateTime(2023, 11, 22, 11, 27, 47, 506, DateTimeKind.Local).AddTicks(4150),
                            IdPessoa = 0,
                            Remetente = "Marilia Mendonça"
                        },
                        new
                        {
                            Id = 3,
                            DataEntrega = new DateTime(2023, 11, 22, 11, 27, 47, 506, DateTimeKind.Local).AddTicks(4151),
                            DataRetirada = new DateTime(2023, 11, 22, 11, 27, 47, 506, DateTimeKind.Local).AddTicks(4151),
                            IdPessoa = 0,
                            Remetente = "Paola Oliveira"
                        },
                        new
                        {
                            Id = 4,
                            DataEntrega = new DateTime(2023, 11, 22, 11, 27, 47, 506, DateTimeKind.Local).AddTicks(4152),
                            DataRetirada = new DateTime(2023, 11, 22, 11, 27, 47, 506, DateTimeKind.Local).AddTicks(4153),
                            IdPessoa = 0,
                            Remetente = "João Gomes"
                        });
                });

            modelBuilder.Entity("CondominusApi.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Perfil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pessoas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cpf = "56751898901",
                            Nome = "João Gomes",
                            Telefone = "11924316523"
                        },
                        new
                        {
                            Id = 2,
                            Cpf = "63158658205",
                            Nome = "Paola Oliveira",
                            Telefone = "11975231678"
                        },
                        new
                        {
                            Id = 3,
                            Cpf = "27458823908",
                            Nome = "Marilia Mendonça",
                            Telefone = "11937512056"
                        },
                        new
                        {
                            Id = 4,
                            Cpf = "32152898910",
                            Nome = "Sorriso Maroto",
                            Telefone = "11987618735"
                        });
                });

            modelBuilder.Entity("CondominusApi.Models.Portaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Portarias");
                });

            modelBuilder.Entity("CondominusApi.Models.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AreaComumId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAreaComum")
                        .HasColumnType("int");

                    b.Property<int>("IdPessoa")
                        .HasColumnType("int");

                    b.Property<int?>("PessoaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AreaComumId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Reservas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Data = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdAreaComum = 0,
                            IdPessoa = 0
                        },
                        new
                        {
                            Id = 2,
                            Data = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdAreaComum = 0,
                            IdPessoa = 0
                        },
                        new
                        {
                            Id = 3,
                            Data = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdAreaComum = 0,
                            IdPessoa = 0
                        },
                        new
                        {
                            Id = 4,
                            Data = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdAreaComum = 0,
                            IdPessoa = 0
                        });
                });

            modelBuilder.Entity("CondominusApi.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApartamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataAcesso")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdApartamento")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Perfil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApartamentoId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "seuEmail@gmail.com",
                            IdApartamento = 1,
                            Nome = "UsuarioAdmin",
                            PasswordHash = new byte[] { 179, 238, 253, 99, 253, 3, 65, 182, 110, 193, 77, 135, 36, 12, 83, 73, 91, 181, 82, 72, 69, 93, 180, 86, 30, 182, 229, 6, 66, 161, 35, 124, 89, 108, 107, 149, 9, 166, 70, 4, 113, 29, 105, 254, 91, 61, 5, 145, 134, 28, 174, 76, 19, 219, 245, 190, 88, 41, 187, 15, 171, 224, 189, 48 },
                            PasswordSalt = new byte[] { 133, 112, 13, 141, 172, 154, 3, 49, 159, 161, 76, 68, 31, 165, 10, 178, 167, 110, 96, 25, 102, 8, 126, 125, 141, 189, 63, 78, 199, 156, 119, 107, 158, 202, 30, 197, 91, 126, 79, 35, 210, 243, 120, 142, 153, 132, 222, 203, 160, 25, 113, 247, 66, 121, 154, 203, 30, 23, 24, 136, 219, 38, 71, 132, 28, 216, 116, 236, 228, 184, 153, 119, 79, 204, 184, 220, 125, 189, 210, 171, 86, 30, 252, 149, 65, 150, 37, 35, 229, 254, 177, 129, 60, 16, 138, 79, 148, 91, 109, 70, 39, 176, 193, 21, 217, 129, 82, 4, 76, 63, 134, 176, 160, 115, 102, 188, 124, 74, 72, 201, 165, 75, 118, 151, 179, 54, 196, 211 },
                            Perfil = "Admin"
                        },
                        new
                        {
                            Id = 3,
                            Email = "email@gmail.com",
                            IdApartamento = 2,
                            Nome = "UsuarioSindico",
                            PasswordHash = new byte[] { 179, 238, 253, 99, 253, 3, 65, 182, 110, 193, 77, 135, 36, 12, 83, 73, 91, 181, 82, 72, 69, 93, 180, 86, 30, 182, 229, 6, 66, 161, 35, 124, 89, 108, 107, 149, 9, 166, 70, 4, 113, 29, 105, 254, 91, 61, 5, 145, 134, 28, 174, 76, 19, 219, 245, 190, 88, 41, 187, 15, 171, 224, 189, 48 },
                            PasswordSalt = new byte[] { 133, 112, 13, 141, 172, 154, 3, 49, 159, 161, 76, 68, 31, 165, 10, 178, 167, 110, 96, 25, 102, 8, 126, 125, 141, 189, 63, 78, 199, 156, 119, 107, 158, 202, 30, 197, 91, 126, 79, 35, 210, 243, 120, 142, 153, 132, 222, 203, 160, 25, 113, 247, 66, 121, 154, 203, 30, 23, 24, 136, 219, 38, 71, 132, 28, 216, 116, 236, 228, 184, 153, 119, 79, 204, 184, 220, 125, 189, 210, 171, 86, 30, 252, 149, 65, 150, 37, 35, 229, 254, 177, 129, 60, 16, 138, 79, 148, 91, 109, 70, 39, 176, 193, 21, 217, 129, 82, 4, 76, 63, 134, 176, 160, 115, 102, 188, 124, 74, 72, 201, 165, 75, 118, 151, 179, 54, 196, 211 },
                            Perfil = "Sindico"
                        },
                        new
                        {
                            Id = 4,
                            Email = "email@gmail.com",
                            IdApartamento = 3,
                            Nome = "UsuarioMorador",
                            PasswordHash = new byte[] { 179, 238, 253, 99, 253, 3, 65, 182, 110, 193, 77, 135, 36, 12, 83, 73, 91, 181, 82, 72, 69, 93, 180, 86, 30, 182, 229, 6, 66, 161, 35, 124, 89, 108, 107, 149, 9, 166, 70, 4, 113, 29, 105, 254, 91, 61, 5, 145, 134, 28, 174, 76, 19, 219, 245, 190, 88, 41, 187, 15, 171, 224, 189, 48 },
                            PasswordSalt = new byte[] { 133, 112, 13, 141, 172, 154, 3, 49, 159, 161, 76, 68, 31, 165, 10, 178, 167, 110, 96, 25, 102, 8, 126, 125, 141, 189, 63, 78, 199, 156, 119, 107, 158, 202, 30, 197, 91, 126, 79, 35, 210, 243, 120, 142, 153, 132, 222, 203, 160, 25, 113, 247, 66, 121, 154, 203, 30, 23, 24, 136, 219, 38, 71, 132, 28, 216, 116, 236, 228, 184, 153, 119, 79, 204, 184, 220, 125, 189, 210, 171, 86, 30, 252, 149, 65, 150, 37, 35, 229, 254, 177, 129, 60, 16, 138, 79, 148, 91, 109, 70, 39, 176, 193, 21, 217, 129, 82, 4, 76, 63, 134, 176, 160, 115, 102, 188, 124, 74, 72, 201, 165, 75, 118, 151, 179, 54, 196, 211 },
                            Perfil = "Morador"
                        });
                });

            modelBuilder.Entity("CondominusApi.Models.ApartPessoa", b =>
                {
                    b.HasOne("CondominusApi.Models.Apartamento", "Apartamento")
                        .WithMany()
                        .HasForeignKey("ApartamentoId");

                    b.HasOne("CondominusApi.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId");

                    b.Navigation("Apartamento");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("CondominusApi.Models.Apartamento", b =>
                {
                    b.HasOne("CondominusApi.Models.Condominio", "Condominio")
                        .WithMany("Apartamentos")
                        .HasForeignKey("CondominioId");

                    b.Navigation("Condominio");
                });

            modelBuilder.Entity("CondominusApi.Models.Aviso", b =>
                {
                    b.HasOne("CondominusApi.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("CondominusApi.Models.Condominio", b =>
                {
                    b.HasOne("CondominusApi.Models.Portaria", "Portaria")
                        .WithMany()
                        .HasForeignKey("PortariaId");

                    b.Navigation("Portaria");
                });

            modelBuilder.Entity("CondominusApi.Models.Dependente", b =>
                {
                    b.HasOne("CondominusApi.Models.Pessoa", "Pessoa")
                        .WithMany("Dependentes")
                        .HasForeignKey("PessoaId");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("CondominusApi.Models.Entrega", b =>
                {
                    b.HasOne("CondominusApi.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId");

                    b.HasOne("CondominusApi.Models.Portaria", null)
                        .WithMany("Entregas")
                        .HasForeignKey("PortariaId");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("CondominusApi.Models.Reserva", b =>
                {
                    b.HasOne("CondominusApi.Models.AreaComum", "AreaComum")
                        .WithMany()
                        .HasForeignKey("AreaComumId");

                    b.HasOne("CondominusApi.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId");

                    b.Navigation("AreaComum");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("CondominusApi.Models.Usuario", b =>
                {
                    b.HasOne("CondominusApi.Models.Apartamento", "Apartamento")
                        .WithMany()
                        .HasForeignKey("ApartamentoId");

                    b.Navigation("Apartamento");
                });

            modelBuilder.Entity("CondominusApi.Models.Condominio", b =>
                {
                    b.Navigation("Apartamentos");
                });

            modelBuilder.Entity("CondominusApi.Models.Pessoa", b =>
                {
                    b.Navigation("Dependentes");
                });

            modelBuilder.Entity("CondominusApi.Models.Portaria", b =>
                {
                    b.Navigation("Entregas");
                });
#pragma warning restore 612, 618
        }
    }
}
