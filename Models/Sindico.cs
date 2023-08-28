using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CondominusApi.Models;


namespace CondominusApi.Models
{
    public class Sindico
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        //public Condominio Condominio { get; set; }
        //public int IdCondominio { get; set; }
    }
}