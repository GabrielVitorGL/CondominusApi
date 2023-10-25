using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominusApi.Models
{
    public class ApartPessoa
    {
        public int Id { get; set; }
        public Apartamento Apartamento { get; set; }
        public int IdApartamento { get; set; }
        public Pessoa Pessoa { get; set; }
        public int IdPessoa { get; set; }
    }
}