using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominusApi.Models
{
    public class Condominio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public Portaria Portaria { get; set; }
        public int IdPortaria { get; set; }
        public List<Apartamento> Apartamentos { set; get; }
    }
}