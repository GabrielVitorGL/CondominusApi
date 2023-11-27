using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominusApi.Models
{
    public class Apartamento
    {
        public int Id { get; set; }
        public string Telefone { get; set; }
        public string Numero { get; set; }
        public Condominio Condominio { get; set; }
        public int IdCondominio { get; set; }
        public List<Entrega> Entregas { get; set; }
        public List<ApartPessoa> Pessoas { get; set; }
    }
}