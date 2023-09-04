using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominusApi.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime DataReserva { get; set; }
        public string Status { get; set; } // Alterar para enum
        public Pessoa Pessoa { get; set; }
        public int IdPessoa { get; set; }
        public AreaComum AreaComum { get; set; }
        public int IdAreaComum { get; set; }
    }
}