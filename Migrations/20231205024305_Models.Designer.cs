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
    [Migration("20231205024305_Models")]
    partial class Models
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
                    b.Property<int>("IdApart")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdApart"));

                    b.Property<int>("IdCondominioApart")
                        .HasColumnType("int");

                    b.Property<string>("NumeroApart")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefoneApart")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdApart");

                    b.HasIndex("IdCondominioApart");

                    b.ToTable("Apartamentos");

                    b.HasData(
                        new
                        {
                            IdApart = 1,
                            IdCondominioApart = 1,
                            NumeroApart = "A001",
                            TelefoneApart = "11912345678"
                        },
                        new
                        {
                            IdApart = 2,
                            IdCondominioApart = 1,
                            NumeroApart = "B002",
                            TelefoneApart = "11912345678"
                        },
                        new
                        {
                            IdApart = 3,
                            IdCondominioApart = 1,
                            NumeroApart = "C003",
                            TelefoneApart = "11887654321"
                        });
                });

            modelBuilder.Entity("CondominusApi.Models.AreaComum", b =>
                {
                    b.Property<int>("IdAreaComum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAreaComum"));

                    b.Property<string>("IdCondominioAreaComum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeAreaComum")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAreaComum");

                    b.ToTable("AreasComuns");

                    b.HasData(
                        new
                        {
                            IdAreaComum = 1,
                            NomeAreaComum = "Churrasqueira"
                        },
                        new
                        {
                            IdAreaComum = 2,
                            NomeAreaComum = "Salão de Jogos"
                        },
                        new
                        {
                            IdAreaComum = 3,
                            NomeAreaComum = "Quadra"
                        });
                });

            modelBuilder.Entity("CondominusApi.Models.Condominio", b =>
                {
                    b.Property<int>("IdCond")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCond"));

                    b.Property<string>("EnderecoCond")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeCond")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCond");

                    b.ToTable("Condominios");

                    b.HasData(
                        new
                        {
                            IdCond = 1,
                            EnderecoCond = "Rua Guaranésia, 1070",
                            NomeCond = "Vila Nova Maria"
                        },
                        new
                        {
                            IdCond = 2,
                            EnderecoCond = "Rua Paulo Andrighetti, 1573",
                            NomeCond = "Condomínio Aquarella Pari Colore"
                        },
                        new
                        {
                            IdCond = 3,
                            EnderecoCond = "Rua Paulo Andrighetti, 449",
                            NomeCond = "Condomínio Edifício Antônio Walter Santiago"
                        });
                });

            modelBuilder.Entity("CondominusApi.Models.Dependente", b =>
                {
                    b.Property<int>("IdDependente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDependente"));

                    b.Property<string>("CpfDependente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPessoaDependente")
                        .HasColumnType("int");

                    b.Property<string>("NomeDependente")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdDependente");

                    b.HasIndex("IdPessoaDependente");

                    b.ToTable("Dependentes");

                    b.HasData(
                        new
                        {
                            IdDependente = 1,
                            CpfDependente = "11242100083",
                            IdPessoaDependente = 1,
                            NomeDependente = "João Gomes"
                        },
                        new
                        {
                            IdDependente = 2,
                            CpfDependente = "30777454025",
                            IdPessoaDependente = 1,
                            NomeDependente = "Maria Silva"
                        },
                        new
                        {
                            IdDependente = 3,
                            CpfDependente = "53086593032",
                            IdPessoaDependente = 2,
                            NomeDependente = "Carlos Oliveira"
                        },
                        new
                        {
                            IdDependente = 4,
                            CpfDependente = "54710630070",
                            IdPessoaDependente = 3,
                            NomeDependente = "Ana Souza"
                        },
                        new
                        {
                            IdDependente = 5,
                            CpfDependente = "03940474002",
                            IdPessoaDependente = 3,
                            NomeDependente = "Pedro Santos"
                        });
                });

            modelBuilder.Entity("CondominusApi.Models.Entrega", b =>
                {
                    b.Property<int>("IdEnt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEnt"));

                    b.Property<string>("CodEnt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataEntregaEnt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataRetiradaEnt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DestinatarioEnt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdApartamentoEnt")
                        .HasColumnType("int");

                    b.HasKey("IdEnt");

                    b.HasIndex("IdApartamentoEnt");

                    b.ToTable("Entregas");

                    b.HasData(
                        new
                        {
                            IdEnt = 1,
                            CodEnt = "NBR1354897",
                            DataEntregaEnt = new DateTime(2023, 12, 4, 23, 43, 5, 102, DateTimeKind.Local).AddTicks(7352),
                            DataRetiradaEnt = new DateTime(2023, 12, 5, 23, 43, 5, 102, DateTimeKind.Local).AddTicks(7363),
                            DestinatarioEnt = "Joao Guilherme",
                            IdApartamentoEnt = 1
                        },
                        new
                        {
                            IdEnt = 2,
                            CodEnt = "NBR2468135",
                            DataEntregaEnt = new DateTime(2023, 12, 4, 23, 43, 5, 102, DateTimeKind.Local).AddTicks(7369),
                            DataRetiradaEnt = new DateTime(2023, 12, 6, 23, 43, 5, 102, DateTimeKind.Local).AddTicks(7370),
                            DestinatarioEnt = "Maria Joaquina",
                            IdApartamentoEnt = 2
                        },
                        new
                        {
                            IdEnt = 3,
                            CodEnt = "NBR3581415",
                            DataEntregaEnt = new DateTime(2023, 12, 4, 23, 43, 5, 102, DateTimeKind.Local).AddTicks(7371),
                            DataRetiradaEnt = new DateTime(2023, 12, 5, 23, 43, 5, 102, DateTimeKind.Local).AddTicks(7372),
                            DestinatarioEnt = "Ana Clara",
                            IdApartamentoEnt = 3
                        });
                });

            modelBuilder.Entity("CondominusApi.Models.Notificacao", b =>
                {
                    b.Property<int>("IdNotificacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdNotificacao"));

                    b.Property<string>("AssuntoNotificacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataEnvioNotificacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdCondominioNotificacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MensagemNotificacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoNotificacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdNotificacao");

                    b.ToTable("Notificacoes");

                    b.HasData(
                        new
                        {
                            IdNotificacao = 1,
                            AssuntoNotificacao = "Manutenção elétrica",
                            DataEnvioNotificacao = new DateTime(2023, 12, 6, 9, 13, 22, 0, DateTimeKind.Unspecified),
                            IdCondominioNotificacao = "1",
                            MensagemNotificacao = "Haverá manutencão no quadro de força do prédio, dia: 20/12 as 14 horas",
                            TipoNotificacao = "Aviso"
                        });
                });

            modelBuilder.Entity("CondominusApi.Models.Pessoa", b =>
                {
                    b.Property<int>("IdPessoa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPessoa"));

                    b.Property<string>("CpfPessoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdApartamentoPessoa")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioPessoa")
                        .HasColumnType("int");

                    b.Property<string>("NomePessoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonePessoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipoPessoa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPessoa");

                    b.HasIndex("IdApartamentoPessoa");

                    b.ToTable("Pessoas");

                    b.HasData(
                        new
                        {
                            IdPessoa = 1,
                            CpfPessoa = "56751898901",
                            IdApartamentoPessoa = 1,
                            NomePessoa = "João Gomes",
                            TelefonePessoa = "11924316523",
                            TipoPessoa = "Admin"
                        },
                        new
                        {
                            IdPessoa = 2,
                            CpfPessoa = "89674156892",
                            IdApartamentoPessoa = 2,
                            NomePessoa = "Maria Oliveira",
                            TelefonePessoa = "1198254351",
                            TipoPessoa = "Morador"
                        },
                        new
                        {
                            IdPessoa = 3,
                            CpfPessoa = "32569874561",
                            IdApartamentoPessoa = 3,
                            NomePessoa = "João Viana",
                            TelefonePessoa = "11984512345",
                            TipoPessoa = "Morador"
                        });
                });

            modelBuilder.Entity("CondominusApi.Models.PessoaAreaComum", b =>
                {
                    b.Property<int>("IdPessoaPessArea")
                        .HasColumnType("int");

                    b.Property<int>("IdAreaComumPessArea")
                        .HasColumnType("int");

                    b.Property<int>("IdPessArea")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPessArea"));

                    b.Property<DateTime>("dataHoraFimPessArea")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dataHoraInicioPessArea")
                        .HasColumnType("datetime2");

                    b.HasKey("IdPessoaPessArea", "IdAreaComumPessArea");

                    b.HasIndex("IdAreaComumPessArea");

                    b.ToTable("PessoasAreasComuns");
                });

            modelBuilder.Entity("CondominusApi.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataAcessoUsuario")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPessoaUsuario")
                        .HasColumnType("int");

                    b.Property<byte[]>("PasswordHashUsuario")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSaltUsuario")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            IdUsuario = 1,
                            EmailUsuario = "admin@gmail.com",
                            IdPessoaUsuario = 1,
                            PasswordHashUsuario = new byte[] { 70, 64, 69, 97, 78, 121, 159, 203, 189, 177, 225, 184, 52, 139, 89, 2, 208, 15, 50, 78, 110, 227, 51, 91, 18, 151, 60, 163, 60, 36, 227, 88, 59, 211, 204, 184, 63, 80, 241, 145, 140, 58, 178, 78, 203, 32, 146, 115, 35, 59, 36, 11, 242, 63, 6, 189, 123, 132, 69, 224, 113, 0, 59, 55 },
                            PasswordSaltUsuario = new byte[] { 217, 46, 16, 164, 54, 210, 182, 15, 128, 124, 4, 166, 163, 90, 195, 127, 62, 111, 209, 151, 224, 32, 11, 28, 174, 227, 134, 119, 136, 73, 135, 227, 55, 97, 28, 95, 197, 161, 104, 38, 125, 192, 54, 114, 238, 102, 146, 222, 148, 84, 10, 49, 14, 161, 196, 161, 130, 120, 145, 74, 27, 245, 245, 54, 133, 86, 159, 45, 146, 163, 89, 121, 86, 54, 140, 74, 213, 140, 243, 55, 159, 48, 89, 52, 217, 15, 121, 128, 139, 190, 53, 192, 137, 66, 4, 219, 9, 221, 86, 114, 46, 99, 102, 175, 234, 189, 89, 162, 245, 56, 93, 38, 66, 63, 229, 219, 128, 183, 166, 199, 5, 157, 225, 128, 95, 168, 31, 57 }
                        });
                });

            modelBuilder.Entity("CondominusApi.Models.Apartamento", b =>
                {
                    b.HasOne("CondominusApi.Models.Condominio", "CondominioApart")
                        .WithMany("ApartamentosCond")
                        .HasForeignKey("IdCondominioApart")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CondominioApart");
                });

            modelBuilder.Entity("CondominusApi.Models.Dependente", b =>
                {
                    b.HasOne("CondominusApi.Models.Pessoa", "PessoaDependente")
                        .WithMany("DependentesPessoa")
                        .HasForeignKey("IdPessoaDependente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PessoaDependente");
                });

            modelBuilder.Entity("CondominusApi.Models.Entrega", b =>
                {
                    b.HasOne("CondominusApi.Models.Apartamento", "ApartamentoEnt")
                        .WithMany("EntregasApart")
                        .HasForeignKey("IdApartamentoEnt")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApartamentoEnt");
                });

            modelBuilder.Entity("CondominusApi.Models.Pessoa", b =>
                {
                    b.HasOne("CondominusApi.Models.Apartamento", "ApartamentoPessoa")
                        .WithMany("PessoasApart")
                        .HasForeignKey("IdApartamentoPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApartamentoPessoa");
                });

            modelBuilder.Entity("CondominusApi.Models.PessoaAreaComum", b =>
                {
                    b.HasOne("CondominusApi.Models.AreaComum", "AreaComumPessArea")
                        .WithMany("PessoaACAreaComum")
                        .HasForeignKey("IdAreaComumPessArea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CondominusApi.Models.Pessoa", "PessoaPessArea")
                        .WithMany("PessoaACPessoa")
                        .HasForeignKey("IdPessoaPessArea")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AreaComumPessArea");

                    b.Navigation("PessoaPessArea");
                });

            modelBuilder.Entity("CondominusApi.Models.Usuario", b =>
                {
                    b.HasOne("CondominusApi.Models.Pessoa", "PessoaUsuario")
                        .WithOne("UsuarioPessoa")
                        .HasForeignKey("CondominusApi.Models.Usuario", "IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PessoaUsuario");
                });

            modelBuilder.Entity("CondominusApi.Models.Apartamento", b =>
                {
                    b.Navigation("EntregasApart");

                    b.Navigation("PessoasApart");
                });

            modelBuilder.Entity("CondominusApi.Models.AreaComum", b =>
                {
                    b.Navigation("PessoaACAreaComum");
                });

            modelBuilder.Entity("CondominusApi.Models.Condominio", b =>
                {
                    b.Navigation("ApartamentosCond");
                });

            modelBuilder.Entity("CondominusApi.Models.Pessoa", b =>
                {
                    b.Navigation("DependentesPessoa");

                    b.Navigation("PessoaACPessoa");

                    b.Navigation("UsuarioPessoa");
                });
#pragma warning restore 612, 618
        }
    }
}
