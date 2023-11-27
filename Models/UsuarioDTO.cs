using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CondominusApi.Models
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Perfil { get; set; }
        public string Email { get; set; }
        public DateTime? DataAcesso { get; set; }
        public Apartamento Apartamento {get; set;}
        public int IdApartamento {get; set;}
    }
}

