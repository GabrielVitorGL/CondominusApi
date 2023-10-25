using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominusApi.Models
{
    public class Portaria
    {
        public int Id { get; set; }
        public List<Entrega> Entregas { get; set; }
    }
}