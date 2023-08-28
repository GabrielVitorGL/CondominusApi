using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominusApi.Models
{
    public class AreaComum
    {
        public int Id { get; set; }
        public int Capacidade { get; set; }
        public string Nome { get; set; }
        public string Status { get; set; } // Alterar para enum
    }
}