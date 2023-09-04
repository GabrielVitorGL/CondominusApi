using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominusApi.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Perfil { get; set; } // Alterar para enum
        public string Telefone { get; set; }
        public string Status { get; set; } // Alterar para enum
        public Apartamento Apartamento { get; set; }
        public int IdApartamento { get; set; }
        public Condominio Condominio { get; set; }
        public int IdCondominio { get; set; }
    }
}