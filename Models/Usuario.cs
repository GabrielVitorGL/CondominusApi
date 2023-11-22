using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CondominusApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Perfil { get; set; } // Se o usuario é morador ou sindico
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string Email { get; set; }
        public DateTime? DataAcesso { get; set; }
        [NotMapped]
        public string Token { get; set; }
        [NotMapped]
        public string PasswordString { get; set; } //using System.ComponentModel.DataAnnotations.Schema;
        public Apartamento Apartamento {get; set;}
        public int IdApartamento {get; set;}
    }
}

