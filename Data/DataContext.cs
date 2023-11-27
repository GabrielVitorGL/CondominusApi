using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CondominusApi.Models;
using CondominusApi.Data;
using System.Data;
using CondominusApi.Utils;

namespace CondominusApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Apartamento> Apartamentos { get; set; }
        public DbSet<ApartPessoa> ApartPessoas { get; set; }
        public DbSet<AreaComum> AreasComuns { get; set; }
        public DbSet<Aviso> Avisos { get; set; }
        public DbSet<Condominio> Condominios { get; set; }
        public DbSet<Dependente> Dependentes { get; set; }
        public DbSet<Entrega> Entregas { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Portaria> Portarias { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dependente>()
            .HasOne(d => d.Pessoa)
            .WithMany(p => p.Dependentes)
            .HasForeignKey(d => d.IdPessoa);

            modelBuilder.Entity<Apartamento>()
            .HasOne(a => a.Condominio)
            .WithMany(c => c.Apartamentos)
            .HasForeignKey(a => a.IdCondominio);

            modelBuilder.Entity<Entrega>()
            .HasOne(e => e.Apartamento)
            .WithMany(a => a.Entregas)
            .HasForeignKey(e => e.IdApartamento);

            modelBuilder.Entity<Condominio>().HasData(
                new Condominio() { Id = 1, Nome = "Vila Nova Maria", Endereco = "Rua Guaranésia, 1070"},
                new Condominio() { Id = 2, Nome = "Condomínio Aquarella Pari Colore", Endereco = "Rua Paulo Andrighetti, 1573"},
                new Condominio() { Id = 3, Nome = "Condomínio Edifício Antônio Walter Santiago", Endereco = "Rua Paulo Andrighetti, 449"},
                new Condominio() { Id = 4, Nome = "Condomínio Edifício Veneza", Endereco = "Rua Eugênio de Freitas, 525"}
            );
            modelBuilder.Entity<Apartamento>().HasData(
                new Apartamento() { Id = 1, Telefone = "11912345678", Numero = "A001", IdCondominio = 1 },
                new Apartamento() { Id = 2, Telefone = "11912345678", Numero = "B002", IdCondominio = 1  },
                new Apartamento() { Id = 3, Telefone = "11887654321", Numero = "C003", IdCondominio = 1  },
                new Apartamento() { Id = 4, Telefone = "11955555555", Numero = "E005", IdCondominio = 1  }
            );
            modelBuilder.Entity<Entrega>().HasData(
                new Entrega() { Id = 1, Destinatario = "Joao Guilherme", DataEntrega = null, DataRetirada = null, IdApartamento = 1 }
            );
            modelBuilder.Entity<AreaComum>().HasData(
                new AreaComum() { Id = 1, Capacidade = 50, Nome = "Salão de Festas" },
                new AreaComum() { Id = 2, Capacidade = 30, Nome = "Churrasqueira" },
                new AreaComum() { Id = 3, Capacidade = 20, Nome = "Sala de Jogos" },
                new AreaComum() { Id = 4, Capacidade = 10, Nome = "Piscina" }
            );
            modelBuilder.Entity<Pessoa>().HasData(
                new Pessoa(){ Id = 1, Nome = "João Gomes", Cpf = "56751898901", Telefone = "11924316523"},
                new Pessoa(){ Id = 2, Nome = "Paola Oliveira", Cpf = "63158658205", Telefone = "11975231678"},
                new Pessoa(){ Id = 3, Nome = "Marilia Mendonça", Cpf = "27458823908", Telefone = "11937512056"},
                new Pessoa(){ Id = 4, Nome = "Sorriso Maroto", Cpf = "32152898910", Telefone = "11987618735"}
            );
            modelBuilder.Entity<Reserva>().HasData(
                new Reserva(){ Id = 1},
                new Reserva(){ Id = 2},
                new Reserva(){ Id = 3},
                new Reserva(){ Id = 4}
            );
            modelBuilder.Entity<Dependente>().HasData(
                new Dependente() { Id = 1, Nome = "João Gomes", Telefone = "11924316523", IdPessoa = 1},
                new Dependente() { Id = 2, Nome = "Maria Silva", Telefone = "11876543210", IdPessoa = 1 },
                new Dependente() { Id = 3, Nome = "Carlos Oliveira", Telefone = "11234567890", IdPessoa = 2 },
                new Dependente() { Id = 4, Nome = "Ana Souza", Telefone = "11987654321", IdPessoa = 3 },
                new Dependente() { Id = 5, Nome = "Pedro Santos", Telefone = "11765432109", IdPessoa = 3 }
            );

            Usuario user = new Usuario();     
            Criptografia.CriarPasswordHash("123456", out byte[] hash, out byte[] salt);
            Criptografia.CriarPasswordHash("654321", out byte[] hashJ, out byte[] saltJ);

            user.Id = 1;
            user.Nome = "UsuarioAdmin";            
            user.Perfil = "Admin";
            user.Email = "admin@gmail.com";
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            user.PasswordString = string.Empty;
            user.IdApartamento = 1;

            modelBuilder.Entity<Usuario>().HasData(user);            
            //Fim da criação do usuário padrão.

            modelBuilder.Entity<Usuario>().HasData
            (
                new Usuario() { Id = 3, Nome = "UsuarioSindico", Perfil = "Sindico", Email = "UsuarioSindico@gmail.com", 
                PasswordHash = hash, PasswordSalt = salt, PasswordString = null, IdApartamento = 2 },
                new Usuario() { Id = 4, Nome = "UsuarioMorador", Perfil = "Morador", Email = "UsuarioMorador@gmail.com", 
                PasswordHash = hash, PasswordSalt = salt, PasswordString = null, IdApartamento = 3 }
            );
        }
    }
}