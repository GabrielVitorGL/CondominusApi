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
        public string Perfil { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public List<Dependente> Dependentes { get; set; }
    }
}