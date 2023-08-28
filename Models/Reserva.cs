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
        public Morador Morador { get; set; }
        public int IdMorador { get; set; }
        public AreaComum AreaComum { get; set; }
        public int IdAreaComum { get; set; }
    }
}