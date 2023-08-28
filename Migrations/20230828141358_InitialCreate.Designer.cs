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
    [Migration("20230828141358_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

            modelBuilder.Entity("CondominusApi.Models.Condominio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Condominios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Endereco = "Rua Guaranésia, 1070",
                            Nome = "Vila Nova Maria"
                        },
                        new
                        {
                            Id = 2,
                            Endereco = "Rua Paulo Andrighetti, 1573",
                            Nome = "Condomínio Aquarella Pari Colore"
                        },
                        new
                        {
                            Id = 3,
                            Endereco = "Rua Paulo Andrighetti, 449",
                            Nome = "Condomínio Edifício Antônio Walter Santiago"
                        },
                        new
                        {
                            Id = 4,
                            Endereco = "Rua Eugênio de Freitas, 525",
                            Nome = "Condomínio Edifício Veneza"
                        });
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

                    b.Property<int>("IdMorador")
                        .HasColumnType("int");

                    b.Property<int?>("MoradorId")
                        .HasColumnType("int");

                    b.Property<string>("Remetente")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MoradorId");

                    b.ToTable("Entregas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataEntrega = new DateTime(2023, 8, 28, 11, 13, 57, 917, DateTimeKind.Local).AddTicks(3535),
                            DataRetirada = new DateTime(2023, 8, 28, 11, 13, 57, 917, DateTimeKind.Local).AddTicks(3546),
                            IdMorador = 0,
                            Remetente = "Sorriso Maroto"
                        },
                        new
                        {
                            Id = 2,
                            DataEntrega = new DateTime(2023, 8, 28, 11, 13, 57, 917, DateTimeKind.Local).AddTicks(3547),
                            DataRetirada = new DateTime(2023, 8, 28, 11, 13, 57, 917, DateTimeKind.Local).AddTicks(3547),
                            IdMorador = 0,
                            Remetente = "Marilia Mendonça"
                        },
                        new
                        {
                            Id = 3,
                            DataEntrega = new DateTime(2023, 8, 28, 11, 13, 57, 917, DateTimeKind.Local).AddTicks(3548),
                            DataRetirada = new DateTime(2023, 8, 28, 11, 13, 57, 917, DateTimeKind.Local).AddTicks(3549),
                            IdMorador = 0,
                            Remetente = "Paola Oliveira"
                        },
                        new
                        {
                            Id = 4,
                            DataEntrega = new DateTime(2023, 8, 28, 11, 13, 57, 917, DateTimeKind.Local).AddTicks(3550),
                            DataRetirada = new DateTime(2023, 8, 28, 11, 13, 57, 917, DateTimeKind.Local).AddTicks(3550),
                            IdMorador = 0,
                            Remetente = "João Gomes"
                        });
                });

            modelBuilder.Entity("CondominusApi.Models.Morador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApartamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdApartamento")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApartamentoId");

                    b.ToTable("Moradores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cpf = "56751898901",
                            IdApartamento = 0,
                            Nome = "João Gomes",
                            Telefone = "11924316523"
                        },
                        new
                        {
                            Id = 2,
                            Cpf = "63158658205",
                            IdApartamento = 0,
                            Nome = "Paola Oliveira",
                            Telefone = "11975231678"
                        },
                        new
                        {
                            Id = 3,
                            Cpf = "27458823908",
                            IdApartamento = 0,
                            Nome = "Marilia Mendonça",
                            Telefone = "11937512056"
                        },
                        new
                        {
                            Id = 4,
                            Cpf = "32152898910",
                            IdApartamento = 0,
                            Nome = "Sorriso Maroto",
                            Telefone = "11987618735"
                        });
                });

            modelBuilder.Entity("CondominusApi.Models.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AreaComumId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataReserva")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAreaComum")
                        .HasColumnType("int");

                    b.Property<int>("IdMorador")
                        .HasColumnType("int");

                    b.Property<int?>("MoradorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AreaComumId");

                    b.HasIndex("MoradorId");

                    b.ToTable("Reservas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataReserva = new DateTime(2023, 8, 28, 11, 13, 57, 917, DateTimeKind.Local).AddTicks(3600),
                            IdAreaComum = 0,
                            IdMorador = 0
                        },
                        new
                        {
                            Id = 2,
                            DataReserva = new DateTime(2023, 8, 28, 11, 13, 57, 917, DateTimeKind.Local).AddTicks(3601),
                            IdAreaComum = 0,
                            IdMorador = 0
                        },
                        new
                        {
                            Id = 3,
                            DataReserva = new DateTime(2023, 8, 28, 11, 13, 57, 917, DateTimeKind.Local).AddTicks(3602),
                            IdAreaComum = 0,
                            IdMorador = 0
                        },
                        new
                        {
                            Id = 4,
                            DataReserva = new DateTime(2023, 8, 28, 11, 13, 57, 917, DateTimeKind.Local).AddTicks(3602),
                            IdAreaComum = 0,
                            IdMorador = 0
                        });
                });

            modelBuilder.Entity("CondominusApi.Models.Sindico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CondominioId")
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCondominio")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CondominioId");

                    b.ToTable("Sindicos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cpf = "12345678900",
                            IdCondominio = 0,
                            Nome = "Eliane Marion",
                            Telefone = "11925874613"
                        });
                });

            modelBuilder.Entity("CondominusApi.Models.Apartamento", b =>
                {
                    b.HasOne("CondominusApi.Models.Condominio", "Condominio")
                        .WithMany()
                        .HasForeignKey("CondominioId");

                    b.Navigation("Condominio");
                });

            modelBuilder.Entity("CondominusApi.Models.Entrega", b =>
                {
                    b.HasOne("CondominusApi.Models.Morador", "Morador")
                        .WithMany()
                        .HasForeignKey("MoradorId");

                    b.Navigation("Morador");
                });

            modelBuilder.Entity("CondominusApi.Models.Morador", b =>
                {
                    b.HasOne("CondominusApi.Models.Apartamento", "Apartamento")
                        .WithMany()
                        .HasForeignKey("ApartamentoId");

                    b.Navigation("Apartamento");
                });

            modelBuilder.Entity("CondominusApi.Models.Reserva", b =>
                {
                    b.HasOne("CondominusApi.Models.AreaComum", "AreaComum")
                        .WithMany()
                        .HasForeignKey("AreaComumId");

                    b.HasOne("CondominusApi.Models.Morador", "Morador")
                        .WithMany()
                        .HasForeignKey("MoradorId");

                    b.Navigation("AreaComum");

                    b.Navigation("Morador");
                });

            modelBuilder.Entity("CondominusApi.Models.Sindico", b =>
                {
                    b.HasOne("CondominusApi.Models.Condominio", "Condominio")
                        .WithMany()
                        .HasForeignKey("CondominioId");

                    b.Navigation("Condominio");
                });
#pragma warning restore 612, 618
        }
    }
}